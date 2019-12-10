using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;
using SmartGateIn.Daemon;
using SmartGateIn.ProcessSteps;
using SmartGateIn.Properties;
using SmartGateIn.SapWebservices;

namespace SmartGateIn
{
    public partial class BaseForm : Form
    {
        private readonly List<IDisposable> _disposeOnProgramExit = new List<IDisposable>();
        private IDisposable _cancelGateInSubscription;

        private ProcessStepBase _currentAction;
        private IDisposable _currentActionTimeout;

        private Queue<Func<ProcessStepBase>> _currentProcess;

        public BaseForm()
        {
            InitializeComponent();
            TopMost = false;
            Hide();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            StartDaemons();
            StartNewProcess();
            EnableNextActionBehaviour();
            Show();
            Activate();
        }

        private void StartDaemons()
        {
            var connectivityDaemon = new ConnectivityDaemon().ShouldLockClient()
                .Replay(1).RefCount();
            var remoteControlDaemon = new RemoteControlDaemon(new RemoteControlService()).ShouldLockClient()
                .Replay(1).RefCount();

            var lockstatus = connectivityDaemon
                .CombineLatest(remoteControlDaemon, (network, remoteControl) => network || remoteControl)
                .DistinctUntilChanged()
                .ObserveOn(ctrlButtonCancel);

            var enableLock = lockstatus
                .Where(activate => activate)
                .SubscribeOn(new EventLoopScheduler())
                .Subscribe(_ => ActivateLock());

            var disableLock = lockstatus
                .Where(activate => !activate)
                .SubscribeOn(new EventLoopScheduler())
                .Subscribe(_ => DeactivateLock());

            _disposeOnProgramExit.Add(enableLock);
            _disposeOnProgramExit.Add(disableLock);
        }

        private void StartNewProcess()
        {
            StopAllSubscriptions();
            SetupNewProcess();
            StartNextAction();
        }

        private void SetupNewProcess()
        {
            ShowUserActionChoices("Check-In starten", false, false);

            var queue = new Queue<Func<ProcessStepBase>>();

            queue.Enqueue(() => new StartUpControl(() =>
            {
                ShowUserActionChoices("Check-In starten", true, true);
                ObserveCancellationConditions();
            }));

            queue.Enqueue(() =>
            {
                ShowUserActionChoices("Weiter", false, true);
                return new ScanControl(() => ctrlButtonNextStep.Enabled = true);
            });

            queue.Enqueue(() =>
            {
                ShowUserActionChoices("Gate öffnen", false, true);
                return new PrintingControl(() => ctrlButtonNextStep.Enabled = true);
            });

            _currentProcess = queue;
        }

        private void ObserveCancellationConditions()
        {
            var currentProcessTimeout = Observable.Interval(TimeSpan.FromSeconds(1))
                .Zip(Enumerable.Range(0, Settings.Default.ProcessTimeoutInSeconds).Reverse().ToObservable(),
                    (_, time) => time)
                .ObserveOn(this)
                .Do(remaining => ctrlButtonProcessTimeout.Text = $@"Verbleibende Zeit: {remaining} Sekunde(n)")
                .Where(remaining => remaining <= 0)
                .Select(_ => new TimeoutException("Die Gesamtdauer für den Prozess wurde überschritten."));

            ActivateCurrentActionTimeout();
            var currentActionTimeout = Observable
                .FromEventPattern(ctrlButtonNextStep, nameof(ctrlButtonNextStep.Click))
                .ObserveOn(this)
                .Do(_ => ActivateCurrentActionTimeout())
                .Timeout(TimeSpan.FromSeconds(Settings.Default.ProcessStepTimeoutInSeconds))
                .SelectMany(_ => Observable.Never<Exception>());

            var userCanceledProcess = Observable
                .FromEventPattern(ctrlButtonCancel, nameof(ctrlButtonCancel.Click))
                .SelectMany(_ =>
                    Observable.Throw<Exception>(new OperationCanceledException("Prozess wurde abgebrochen.")));

            _cancelGateInSubscription = currentProcessTimeout
                .Amb(userCanceledProcess)
                .Amb(currentActionTimeout)
                .ObserveOn(this)
                .Subscribe(
                    ex => { },
                    exception =>
                    {
                        MessageBox.Show(exception.Message);
                        StartNewProcess();
                    });
        }

        private void ActivateCurrentActionTimeout()
        {
            _currentActionTimeout?.Dispose();

            var seconds = Enumerable.Range(0, Settings.Default.ProcessStepTimeoutInSeconds).Reverse().ToObservable();

            _currentActionTimeout = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Zip(seconds, (_, time) => time)
                .SubscribeOn(new EventLoopScheduler())
                .ObserveOn(ctrlButtonActionTimeout)
                .Subscribe(remaining => ctrlButtonActionTimeout.Text = $@"Verbleibende Zeit: {remaining} Sekunde(n)");
        }

        private void StartNextAction()
        {
            if (_currentProcess.Count == 0)
            {
                StartNewProcess();
                return;
            }

            _currentAction = _currentProcess.Dequeue()();
            ShowUserActionHint();
        }

        private void DeactivateLock()
        {
            if (_currentAction.GetType() != typeof(LockControl))
                return;

            ctrlPanelFooter.Visible = true;

            StartNewProcess();
        }

        private void ActivateLock()
        {
            StopAllSubscriptions();

            ctrlPanelFooter.Visible = false;

            _currentAction = new LockControl();
            ShowUserActionHint();
        }

        private void StopAllSubscriptions()
        {
            _currentAction?.Dispose();
            _cancelGateInSubscription?.Dispose();
            _currentActionTimeout?.Dispose();

            _currentProcess?.Clear();

            ctrlButtonActionTimeout.Text = string.Empty;
            ctrlButtonProcessTimeout.Text = string.Empty;
        }

        private void ShowUserActionHint()
        {
            ctrlPanelCurrentStep.Controls.Clear();

            Text = _currentAction.Title;
            ctrlLabelHeader.Text = _currentAction.Description;

            if (ctrlPanelCurrentStep.HasChildren)
                ctrlPanelCurrentStep.Controls.RemoveAt(0);

            ctrlPanelCurrentStep.Controls.Add(_currentAction);
            _currentAction.Dock = DockStyle.Fill;
        }

        private void ShowUserActionChoices(string text, bool enableNextStep, bool enableCancel)
        {
            ctrlButtonNextStep.Text = text;
            ctrlButtonNextStep.Enabled = enableNextStep;
            ctrlButtonCancel.Enabled = enableCancel;
        }

        private void EnableNextActionBehaviour()
        {
            var sub = Observable.FromEventPattern(ctrlButtonNextStep, nameof(ctrlButtonNextStep.Click))
                .ObserveOn(ctrlButtonNextStep)
                .Subscribe(_ => StartNextAction());

            _disposeOnProgramExit.Add(sub);
        }

        private void ExitProgram(object sender, FormClosingEventArgs e)
        {
            _disposeOnProgramExit?.ForEach(sub => sub?.Dispose());
            _cancelGateInSubscription?.Dispose();
        }
    }
}
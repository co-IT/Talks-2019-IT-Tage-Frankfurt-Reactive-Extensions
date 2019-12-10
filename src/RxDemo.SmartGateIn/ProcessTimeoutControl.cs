using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace SmartGateIn
{
    public partial class ProcessTimeoutControl : UserControl
    {
        private readonly string _message;
        private IDisposable _timer;

        public ProcessTimeoutControl()
        {
            InitializeComponent();
        }

        public ProcessTimeoutControl(string message)
            : this() => _message = message;

        internal void Stop()
        {
            label1.Text = string.Empty;
            _timer?.Dispose();
        }

        internal IObservable<Exception> StartOrRestart(int timeoutInSeconds)
        {
            Stop();

            var seconds = Enumerable.Range(0, timeoutInSeconds).Reverse().ToObservable();

            _timer = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Zip(seconds, (_, time) => time)
                .SubscribeOn(new EventLoopScheduler())
                .ObserveOn(label1)
                .Subscribe(remaining => label1.Text = $@"Verbleibende Zeit: {remaining} Sekunde(n)");

            return Observable
                .Throw<TimeoutException>(new TimeoutException(_message))
                .DelaySubscription(TimeSpan.FromSeconds(timeoutInSeconds));
        }
    }
}
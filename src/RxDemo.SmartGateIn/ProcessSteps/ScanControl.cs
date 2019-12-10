using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;
using RxDemo.VirtualScanner;
using SmartGateIn.SapWebservices;

// ReSharper disable ConvertToLocalFunction

namespace SmartGateIn.ProcessSteps
{
    public partial class ScanControl : ProcessStepBase
    {
        private readonly IGateInService _sapService = new GateInService();
        
        private IDisposable _userNotificationSubscription;
        private IDisposable _scanResultProcessorSubscription;
        
        private Action _startScanner;
        private Action _startStopScanner;
        private Action _stopScanner;

        public ScanControl(Action onSuccess)
            :base("Unterlagen scannen", "Bitte halten Sie Ihre Unterlagen unter den Scanner.", onSuccess)
        {
            InitializeComponent();
            InitializeScanner();
        }

        private void InitializeScanner()
        {
            _stopScanner = () =>
            {
                chkBox_ScannerStatus.BackColor = Color.OrangeRed;
                chkBox_ScannerStatus.Text = "Scanner aktivieren";
                StopScan();
                _startStopScanner = _startScanner;
            };

            _startScanner = () =>
            {
                chkBox_ScannerStatus.BackColor = Color.GreenYellow;
                chkBox_ScannerStatus.Text = "Scanner deaktivieren";
                StartScan();
                _startStopScanner = _stopScanner;
            };

            _startStopScanner = _startScanner;
        }

        private void StartScan()
        {
            var scans = Observable
                .Using(
                    () => BarcodeScanner.Virtual(),
                    scanner => scanner.ListenToScanner(AcceptableScans())
                )
                .SubscribeOn(TaskPoolScheduler.Default)
                .Replay()
                .RefCount();

            _userNotificationSubscription = scans
                .ObserveOn(label1)
                .Subscribe(val => NotifyUser(val));

            _scanResultProcessorSubscription = scans
                .SelectMany(scan => _sapService.GetInstructionsFor(scan))
                .Where(gateInDetails => gateInDetails != null)
                .SubscribeOn(ThreadPoolScheduler.Instance)
                .ObserveOn(label1)
                .Subscribe(
                    gateInDetails => GateInAllowed(gateInDetails),
                    ex => GateInRestricted(),
                    () => GateInRestricted()
                );
        }

        private void StopScan() => StopAllSubscriptions();

        private void EnableDisableScanner(object sender, EventArgs e) => _startStopScanner();

        private static Func<string, bool> AcceptableScans()
        {
            Func<string, bool> predicate = scannedValue =>
                !string.IsNullOrWhiteSpace(scannedValue)
                && scannedValue.Length > 3;

            return predicate;
        }

        private void GateInRestricted()
        {
            MessageBox.Show("Zu viele falsche Scans");

            StopAllSubscriptions();
            throw new InvalidOperationException("Zu viele falsche Scans");
        }

        private void GateInAllowed(GateInInstructions gateInInstructions)
        {
            txtBox_Results.Text = gateInInstructions.ToString();

            chkBox_ScannerStatus.Checked = false;
            chkBox_ScannerStatus.Enabled = false;

            StopAllSubscriptions();

            _onSuccess();
        }

        private void StopAllSubscriptions()
        {
            _scanResultProcessorSubscription?.Dispose();
            _userNotificationSubscription?.Dispose();
        }

        private void NotifyUser(IEnumerable<string> scan)
        {
            txtBox_Scanned.Text = scan.Aggregate(string.Empty, (current, next) 
                => string.IsNullOrWhiteSpace(current) ? next : $"{current}{Environment.NewLine}{next}");
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }

            StopAllSubscriptions();

            base.Dispose(disposing);
        }
    }
}
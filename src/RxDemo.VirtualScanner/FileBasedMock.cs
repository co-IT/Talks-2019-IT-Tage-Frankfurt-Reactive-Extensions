using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo.VirtualScanner
{
    internal class FileBasedMock : IMockRealScanner
    {
        private readonly IDisposable _subscription;
        public event EventHandler<string> DataReceived;

        public FileBasedMock()
        {
            _subscription = Observable
                .Using(
                () => CreateFileWatcher(), 
                watcher => CreateProducer(watcher)
                )
                .Subscribe(scan => DataReceived?.Invoke(this, scan));
        }

        public void Dispose()
        {
            ConsolePrinter.WriteLine("RealBarcodeScanner disposed", ConsoleColor.DarkRed);
            _subscription.Dispose();
        }

        private static IObservable<string> CreateProducer(FileSystemWatcher watcher)
        {
            return Observable
                .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                    e => watcher.Changed += e,
                    f => watcher.Changed -= f)
                .Select(change => File.ReadAllLines(change.EventArgs.FullPath).Last());
        }

        private static FileSystemWatcher CreateFileWatcher()
        {
            var directory = Path.GetTempPath();
            var fileWithScanValues = Path.Combine(directory, "scan.txt");

            if (!File.Exists(fileWithScanValues))
            {
                File.Create(fileWithScanValues);
            }

            return new FileSystemWatcher(directory)
            {
                Filter = Path.GetFileName(fileWithScanValues),
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };
        }
    }
}
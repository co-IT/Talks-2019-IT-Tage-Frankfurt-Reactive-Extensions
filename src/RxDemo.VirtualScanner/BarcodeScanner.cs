using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace RxDemo.VirtualScanner
{
    public class BarcodeScanner : IDisposable
    {
        private readonly Func<IMockRealScanner> _createResourceFactory;

        private BarcodeScanner(Func<IMockRealScanner> createResourceFactory)
        {
            _createResourceFactory = createResourceFactory;
        }

        public static BarcodeScanner Virtual()
        {
            return new BarcodeScanner(() => new FileBasedMock());
        }

        public static BarcodeScanner Random()
        {
            return new BarcodeScanner(() => new RandomGeneratorBasedMock());
        }

        public IObservable<IList<string>> ListenToScanner(Func<string, bool> filterScans)
        {
            var scans = Observable
                .Using(
                    () => _createResourceFactory(),
                    realScanner => CreateObservableFactory(realScanner)
                )
                .Select(@event => @event.EventArgs.Trim())
                .Where(filterScans)
                .Distinct()
                .Do(scannedString =>
                {
                    ConsolePrinter.WriteLine($"Scanner produced {scannedString}", ConsoleColor.Red);
                });

            var minimumScans = scans.Buffer(2);
            var maximumScans = scans.Buffer(3);

            return minimumScans.Merge(maximumScans);
        }

        public void Dispose()
        {
            ConsolePrinter.WriteLine("Scanner disposed", ConsoleColor.Red);
        }

        private static IObservable<EventPattern<string>> CreateObservableFactory(IMockRealScanner realScanner)
        {
            return Observable
                .FromEventPattern<string>(
                    add => realScanner.DataReceived += add,
                    remove => realScanner.DataReceived -= remove
                );
        }
    }
}
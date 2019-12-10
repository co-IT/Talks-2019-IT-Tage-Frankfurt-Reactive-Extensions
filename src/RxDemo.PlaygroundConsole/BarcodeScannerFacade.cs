using System;
using System.Reactive;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    internal class BarcodeScannerFacade : IDisposable
    {
        public void Dispose()
        {
            ConsolePrinter.WriteLine("Scanner disposed", ConsoleColor.Red);
        }

        public IObservable<string> ListenToScanner(Func<string, bool> filterScans)
        {
            return Observable
                .Using(
                    () => CreateResourceFactory(),
                    realScanner => CreateObservableFactory(realScanner)
                )
                .Select(@event => @event.EventArgs.Trim())
                .Where(filterScans)
                .Distinct()
                .Do(scannedString =>
                {
                    var col = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Scanner produced {scannedString}");
                    Console.ForegroundColor = col;
                });
        }

        private static RealBarcodeScanner CreateResourceFactory()
        {
            return new RealBarcodeScanner();
        }

        private static IObservable<EventPattern<string>> CreateObservableFactory(RealBarcodeScanner realScanner)
        {
            return Observable
                .FromEventPattern<string>(
                    add => realScanner.DataReceived += add,
                    remove => realScanner.DataReceived -= remove
                );
        }
    }
}
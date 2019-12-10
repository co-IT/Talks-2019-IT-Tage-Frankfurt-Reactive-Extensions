using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace RxDemo.PlaygroundConsole
{
    internal class Sample4 : IAmASample
    {
        public void TimeToDemonstrate()
        {
            var sapBackend = new SapBackend();

            var scanFilter = ComposeScanFilter();

            var scans = Observable
                .Using(
                    () => new BarcodeScannerFacade(),
                    scanner => scanner.ListenToScanner(scanFilter)
                )
                .Replay()
                .RefCount();
            
            Thread.Sleep(TimeSpan.FromSeconds(1));

            ConsolePrinter.WriteLine("Starting Subscription 1", ConsoleColor.Blue);
            var sub1 = scans.Subscribe(val => NotifyUser(val));
            Thread.Sleep(TimeSpan.FromSeconds(2));

            ConsolePrinter.WriteLine("Starting Subscription 2", ConsoleColor.Green);
            var sub2 = scans
                .SelectMany(scan => sapBackend.CheckAuthorization(scan))
                .Subscribe(answer => GateInIfAllowed(answer));

            ConsolePrinter.WriteLine("Starting Producer\n", ConsoleColor.Red);
            Thread.Sleep(TimeSpan.FromSeconds(3));

            sub1.Dispose();
            sub2.Dispose();
    

            Console.ReadKey();
        }

        private static Func<string, bool> ComposeScanFilter()
        {
            Func<string, bool> predicate = scannedValue =>
                !string.IsNullOrWhiteSpace(scannedValue)
                && scannedValue.Length > 3;

            return predicate;
        }

        private static void GateInIfAllowed(string restriction)
        {
            ConsolePrinter.WriteLine(restriction, ConsoleColor.Green);
        }

        private static void NotifyUser(string val)
        {
            ConsolePrinter.WriteLine($"UI NOTIFICATION: you scanned {val}", ConsoleColor.Blue);
        }
    }

    internal class SapBackend
    {
        public IObservable<string> CheckAuthorization(string val)
        {
            //return GetValueSimulatingWebserviceCall(val).ToObservable();
            return Observable
                .FromAsync(() => GetValueSimulatingWebserviceCall(val));
        }

        private Task<string> GetValueSimulatingWebserviceCall(string val)
        {
            Task.Delay(2000);

            var restriction = "can";
            if (DateTime.Now.Second % 2 == 0)
                restriction = "cannot";

            return Observable.Return($"User {restriction} gate in for scan {val}").ToTask();
        }
    }
}
using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    internal class RealBarcodeScanner : IDisposable
    {
        private readonly Random _random = new Random();
        private readonly IDisposable _subscription;
        private int _lengthOfGeneratedString = 1;

        public RealBarcodeScanner()
        {
            _subscription = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => RandomString())
                .Subscribe(scan => DataReceived?.Invoke(this, scan));
        }

        public void Dispose()
        {
            Console.WriteLine("RealBarcodeScanner disposed");
            _subscription.Dispose();
        }

        public event EventHandler<string> DataReceived;

        private string RandomString()
        {
            _lengthOfGeneratedString += 1;

            var alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var chars = Enumerable
                .Repeat(alphanumeric, _lengthOfGeneratedString)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray();

            return new string(chars);
        }
    }
}
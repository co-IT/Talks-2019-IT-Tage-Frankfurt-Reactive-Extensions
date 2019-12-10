using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo.VirtualScanner
{
    internal class RandomGeneratorBasedMock : IMockRealScanner
    {
        private readonly Random _random = new Random();
        private readonly IDisposable _subscription;
        private int _lengthOfGeneratedString = 1;

        public RandomGeneratorBasedMock()
        {
            _subscription = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => RandomString())
                .Subscribe(scan => DataReceived?.Invoke(this, scan));
        }

        public event EventHandler<string> DataReceived;

        public void Dispose()
        {
            ConsolePrinter.WriteLine("RealBarcodeScanner disposed", ConsoleColor.DarkRed);
            _subscription.Dispose();
        }

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
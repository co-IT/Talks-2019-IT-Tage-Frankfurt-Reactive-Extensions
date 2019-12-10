using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    internal class SampleTimeout : IAmASample
    {
        public void TimeToDemonstrate()
        {
            var timer = Observable.Interval(TimeSpan.FromSeconds(1))
                .Zip(Enumerable.Range(0, 10).Reverse().ToObservable(),
                    (_, time) => time)
                .Do(x => Console.WriteLine(x))
                .Where(remaining => remaining <= 0)
                .Select(_ => new TimeoutException("Die Gesamtdauer für den Prozess wurde überschritten."));

            var subscriber = timer.Subscribe(
                x => Console.WriteLine(x)
            );
        }
    }
}
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxDemo.PlaygroundConsole
{
    internal class SampleTimeout : IAmASample
    {
        public void TimeToDemonstrate()
        {
            var timer2 = Enumerable.Range(0, 10).Reverse().ToObservable()
                .Select(val =>
                {
                    Thread.Sleep(1000);
                    return val;
                });

            var timer = Observable.Interval(TimeSpan.FromSeconds(1))
                .Zip(Enumerable.Range(0, 10).Reverse().ToObservable(),
                    (_, time) => time)
                .Do(x => Console.WriteLine(x))
                .Where(remaining => remaining <= 0)
                .Select(_ => new TimeoutException("Die Gesamtdauer für den Prozess wurde überschritten."));

            var subscriber = timer2.Subscribe(
                x => Console.WriteLine(x)
            );
        }
    }
}
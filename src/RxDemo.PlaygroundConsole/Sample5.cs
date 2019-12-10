using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    public class Sample5 : IAmASample
    {
        public void TimeToDemonstrate()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Zip(Enumerable
                    .Range(1,10).Reverse()
                    .ToObservable(), (_, time) => time)
                .Subscribe(val => Console.WriteLine("Timeout in " + val));
        }
    }
}
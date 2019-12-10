using System;
using System.Reactive.Linq;
using System.Threading;

namespace RxDemo.PlaygroundConsole
{
    internal class Sample3 : IAmASample
    {
        public void TimeToDemonstrate()
        {
            Console.WriteLine("Hot Observable keep tracking of everything");

            var timespan = TimeSpan.FromSeconds(1);

            var bar = Observable
                .Interval(timespan)
                .Do(val => Console.WriteLine($"Produced: {val}"))
                .Publish();

            bar.Connect();
            bar = bar.Replay();

            Thread.Sleep(timespan);
            var sub1 = bar.Subscribe(
                val => Console.WriteLine($"Subscriber 1: {val}"),
                () => Console.WriteLine("Subscriber 1 finished"));
            Console.WriteLine("Subscriber 1 created");

            Thread.Sleep(timespan);
            var sub2 = bar.Subscribe(
                val => Console.WriteLine($"Subscriber 2: {val}"),
                () => Console.WriteLine("Subscriber 2 finished"));
            Console.WriteLine("Subscriber 2 created");

            Thread.Sleep(timespan);
            var sub3 = bar.Subscribe(
                val => Console.WriteLine($"Subscriber 3: {val}"),
                () => Console.WriteLine("Subscriber 3 finished"));
            Console.WriteLine("Subscriber 3 created");


            Thread.Sleep(TimeSpan.FromSeconds(5));
            sub1.Dispose();
            sub2.Dispose();
            sub3.Dispose();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
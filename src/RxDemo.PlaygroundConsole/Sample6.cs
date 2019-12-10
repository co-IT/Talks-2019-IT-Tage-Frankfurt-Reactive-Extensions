using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    public class Sample6 : IAmASample
    {
        public void TimeToDemonstrate()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(_ => Console.WriteLine("500ms"));
            Observable.Interval(TimeSpan.FromMilliseconds(1990)).Timeout(TimeSpan.FromMilliseconds(1970))
                .Subscribe(_ => { }, exception => Console.WriteLine("Also an Exception"));

            var total = Observable.Throw<TimeoutException>(new TimeoutException("gesamt")).DelaySubscription(TimeSpan.FromSeconds(10));
            var process = Observable.Throw<TimeoutException>(new TimeoutException("process")).DelaySubscription(TimeSpan.FromSeconds(8));

            total
                .Amb(process)
                .Subscribe(ex =>{}, exception => Console.WriteLine(exception.Message));

            Console.ReadKey();
        }
    }

}
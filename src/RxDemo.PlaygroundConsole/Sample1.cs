using System;
using System.Reactive.Linq;

namespace RxDemo.PlaygroundConsole
{
    internal class Sample1 : IAmASample
    {
        public void TimeToDemonstrate()
        {
            Console.WriteLine("Hot Observable");

            var x = 1;
            var xs = Observable.Return(x);
            xs.Subscribe(val => Observer1(val), () => Console.WriteLine("Observer1 finished"));

            x = 5;
            xs.Subscribe(val => Observer2(val), () => Console.WriteLine("Observer2 finished"));
        }

        private void Observer1(int val)
        {
            Console.WriteLine("Observer1 1 says: " + val);
        }

        private void Observer2(int val)
        {
            Console.WriteLine("Observer1 2 says: " + val);
        }
    }
}
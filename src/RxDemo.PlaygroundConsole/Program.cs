using System;
using System.Collections.Generic;
using System.Linq;

namespace RxDemo.PlaygroundConsole
{
    class Program
    {
        static void Main()
        {
            var samples = new List<IAmASample>()
            {
                new Sample1(),
                new Sample2(),
                new Sample3(),
                new Sample4(),
                new Sample5(),
                new Sample6(),
                new SampleTimeout()
            };

            samples.Last().TimeToDemonstrate();

            Console.ReadKey();
        }
    }
}
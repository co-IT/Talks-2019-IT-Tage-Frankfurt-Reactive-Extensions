using System;

namespace RxDemo.VirtualScanner
{
    internal static class ConsolePrinter
    {
        public static void WriteLine(string message, ConsoleColor color)
        {
            var col = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = col;
        }
    }
}
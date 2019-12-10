using System;

namespace RxDemo.VirtualScanner
{
    internal interface IMockRealScanner : IDisposable
    {
        event EventHandler<string> DataReceived;
    }
}
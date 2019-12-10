using System;
using System.Collections.Generic;

namespace SmartGateIn.SapWebservices
{
    internal interface IGateInService
    {
        IObservable<GateInInstructions> GetInstructionsFor(IEnumerable<string> scans);
    }
}
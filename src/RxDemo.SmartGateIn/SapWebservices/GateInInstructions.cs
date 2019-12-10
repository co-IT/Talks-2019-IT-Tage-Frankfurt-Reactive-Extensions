namespace SmartGateIn.SapWebservices
{
    internal class GateInInstructions
    {
        public int Hall { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }

       public override string ToString()
       {
           return $@"Halle: {Hall}, Reihe: {Row}, Position: {Position}";
       }
    }
}
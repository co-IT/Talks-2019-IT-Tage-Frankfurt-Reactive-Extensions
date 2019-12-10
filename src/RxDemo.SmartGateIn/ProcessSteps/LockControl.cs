namespace SmartGateIn.ProcessSteps
{
    public partial class LockControl : ProcessStepBase
    {
        public LockControl()
            : base("System gesperrt", "Aktuell steht das System leider nicht zur Verfügung.", () => { })
        {
            InitializeComponent();
        }
    }
}
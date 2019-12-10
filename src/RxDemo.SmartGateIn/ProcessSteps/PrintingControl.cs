using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SmartGateIn.ProcessSteps
{
    public partial class PrintingControl : ProcessStepBase
    {
        public PrintingControl(Action onSuccess)
            : base("Ausdruck Abholschein", "Sie können Ihren Abholschein jetzt drucken.", onSuccess)
        {
            InitializeComponent();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            var packingSlip = Path.Combine(Directory.GetCurrentDirectory(), "assets", "Abholschein.pdf");

            if (!File.Exists(packingSlip))
            {
                MessageBox.Show("Erst gültigen Barcode scannen");
                return;
            }

            Process.Start(packingSlip);

            _onSuccess();
        }
    }
}
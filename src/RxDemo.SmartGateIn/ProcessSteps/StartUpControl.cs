using System;
using System.Windows.Forms;

namespace SmartGateIn.ProcessSteps
{
    public partial class StartUpControl : ProcessStepBase
    {

        public StartUpControl(Action onSuccess)
        :base("Willommen", "Drücken Sie Start um mit dem digitalen Einchecken zu beginnen.", onSuccess)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _onSuccess();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Foo");
        }

        private void StartUpControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Foo");

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Foo");

        }
    }
}
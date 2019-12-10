using System;
using System.Windows.Forms;

namespace SmartGateIn.ProcessSteps
{
    public class ProcessStepBase : UserControl, IAmAProcessStep
    {
        protected readonly Action _onSuccess;
        public string Title { get; }
        public string Description { get; }

        public ProcessStepBase()
        {
            InitializeComponent();
        }

        internal ProcessStepBase(string title, string description, Action onSuccess)
        {
            _onSuccess = onSuccess;
            Title = title;
            Description = description;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProcessStepBase
            // 
            this.Name = "ProcessStepBase";
            this.Size = new System.Drawing.Size(752, 580);
            this.MinimumSize = new System.Drawing.Size(752, 580);
            this.MaximumSize = new System.Drawing.Size(752, 580);
            this.ResumeLayout(false);

        }
    }
}
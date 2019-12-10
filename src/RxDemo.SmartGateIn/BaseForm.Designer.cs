namespace SmartGateIn
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Label ctrlLabelHeader;
        private System.Windows.Forms.Panel ctrlPanelTotalTimer;
        private System.Windows.Forms.Panel ctrlPanelHeader;
        private System.Windows.Forms.Panel ctrlPanelFooter;
        private System.Windows.Forms.Panel ctrlPanelCurrentStep;
        private System.Windows.Forms.Button ctrlButtonCancel;
        private System.Windows.Forms.Button ctrlButtonNextStep;
        private System.Windows.Forms.Panel ctrlPanelActionTimer;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlLabelHeader = new System.Windows.Forms.Label();
            this.ctrlPanelTotalTimer = new System.Windows.Forms.Panel();
            this.ctrlButtonProcessTimeout = new System.Windows.Forms.Button();
            this.ctrlPanelHeader = new System.Windows.Forms.Panel();
            this.ctrlPanelFooter = new System.Windows.Forms.Panel();
            this.ctrlButtonCancel = new System.Windows.Forms.Button();
            this.ctrlButtonNextStep = new System.Windows.Forms.Button();
            this.ctrlPanelActionTimer = new System.Windows.Forms.Panel();
            this.ctrlButtonActionTimeout = new System.Windows.Forms.Button();
            this.ctrlPanelCurrentStep = new System.Windows.Forms.Panel();
            this.ctrlPanelTotalTimer.SuspendLayout();
            this.ctrlPanelHeader.SuspendLayout();
            this.ctrlPanelFooter.SuspendLayout();
            this.ctrlPanelActionTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLabelHeader
            // 
            this.ctrlLabelHeader.AutoSize = true;
            this.ctrlLabelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLabelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLabelHeader.Location = new System.Drawing.Point(0, 0);
            this.ctrlLabelHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ctrlLabelHeader.Name = "ctrlLabelHeader";
            this.ctrlLabelHeader.Size = new System.Drawing.Size(0, 25);
            this.ctrlLabelHeader.TabIndex = 3;
            this.ctrlLabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPanelTotalTimer
            // 
            this.ctrlPanelTotalTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPanelTotalTimer.BackColor = System.Drawing.Color.Silver;
            this.ctrlPanelTotalTimer.Controls.Add(this.ctrlButtonProcessTimeout);
            this.ctrlPanelTotalTimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctrlPanelTotalTimer.Location = new System.Drawing.Point(530, 0);
            this.ctrlPanelTotalTimer.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPanelTotalTimer.MinimumSize = new System.Drawing.Size(0, 20);
            this.ctrlPanelTotalTimer.Name = "ctrlPanelTotalTimer";
            this.ctrlPanelTotalTimer.Size = new System.Drawing.Size(222, 89);
            this.ctrlPanelTotalTimer.TabIndex = 2;
            // 
            // ctrlButtonProcessTimeout
            // 
            this.ctrlButtonProcessTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlButtonProcessTimeout.FlatAppearance.BorderSize = 0;
            this.ctrlButtonProcessTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctrlButtonProcessTimeout.Location = new System.Drawing.Point(0, 0);
            this.ctrlButtonProcessTimeout.Name = "ctrlButtonProcessTimeout";
            this.ctrlButtonProcessTimeout.Size = new System.Drawing.Size(222, 89);
            this.ctrlButtonProcessTimeout.TabIndex = 0;
            this.ctrlButtonProcessTimeout.Text = "button1";
            this.ctrlButtonProcessTimeout.UseVisualStyleBackColor = true;
            // 
            // ctrlPanelHeader
            // 
            this.ctrlPanelHeader.AutoSize = true;
            this.ctrlPanelHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPanelHeader.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPanelHeader.Controls.Add(this.ctrlLabelHeader);
            this.ctrlPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPanelHeader.MinimumSize = new System.Drawing.Size(0, 60);
            this.ctrlPanelHeader.Name = "ctrlPanelHeader";
            this.ctrlPanelHeader.Size = new System.Drawing.Size(752, 60);
            this.ctrlPanelHeader.TabIndex = 3;
            // 
            // ctrlPanelFooter
            // 
            this.ctrlPanelFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPanelFooter.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPanelFooter.Controls.Add(this.ctrlButtonCancel);
            this.ctrlPanelFooter.Controls.Add(this.ctrlButtonNextStep);
            this.ctrlPanelFooter.Controls.Add(this.ctrlPanelTotalTimer);
            this.ctrlPanelFooter.Controls.Add(this.ctrlPanelActionTimer);
            this.ctrlPanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlPanelFooter.Location = new System.Drawing.Point(0, 640);
            this.ctrlPanelFooter.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPanelFooter.MinimumSize = new System.Drawing.Size(0, 80);
            this.ctrlPanelFooter.Name = "ctrlPanelFooter";
            this.ctrlPanelFooter.Size = new System.Drawing.Size(752, 89);
            this.ctrlPanelFooter.TabIndex = 1;
            // 
            // ctrlButtonCancel
            // 
            this.ctrlButtonCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlButtonCancel.Enabled = false;
            this.ctrlButtonCancel.FlatAppearance.BorderSize = 0;
            this.ctrlButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlButtonCancel.Location = new System.Drawing.Point(222, 0);
            this.ctrlButtonCancel.Name = "ctrlButtonCancel";
            this.ctrlButtonCancel.Size = new System.Drawing.Size(154, 89);
            this.ctrlButtonCancel.TabIndex = 2;
            this.ctrlButtonCancel.Text = "Abbrechen";
            this.ctrlButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ctrlButtonNextStep
            // 
            this.ctrlButtonNextStep.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctrlButtonNextStep.FlatAppearance.BorderSize = 0;
            this.ctrlButtonNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlButtonNextStep.Location = new System.Drawing.Point(376, 0);
            this.ctrlButtonNextStep.Name = "ctrlButtonNextStep";
            this.ctrlButtonNextStep.Size = new System.Drawing.Size(154, 89);
            this.ctrlButtonNextStep.TabIndex = 1;
            this.ctrlButtonNextStep.Text = "Weiter";
            this.ctrlButtonNextStep.UseVisualStyleBackColor = true;
            // 
            // ctrlPanelActionTimer
            // 
            this.ctrlPanelActionTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPanelActionTimer.BackColor = System.Drawing.Color.Silver;
            this.ctrlPanelActionTimer.Controls.Add(this.ctrlButtonActionTimeout);
            this.ctrlPanelActionTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlPanelActionTimer.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanelActionTimer.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPanelActionTimer.MinimumSize = new System.Drawing.Size(0, 20);
            this.ctrlPanelActionTimer.Name = "ctrlPanelActionTimer";
            this.ctrlPanelActionTimer.Size = new System.Drawing.Size(222, 89);
            this.ctrlPanelActionTimer.TabIndex = 0;
            // 
            // ctrlButtonActionTimeout
            // 
            this.ctrlButtonActionTimeout.AutoSize = true;
            this.ctrlButtonActionTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlButtonActionTimeout.FlatAppearance.BorderSize = 0;
            this.ctrlButtonActionTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctrlButtonActionTimeout.Location = new System.Drawing.Point(0, 0);
            this.ctrlButtonActionTimeout.Name = "ctrlButtonActionTimeout";
            this.ctrlButtonActionTimeout.Size = new System.Drawing.Size(222, 89);
            this.ctrlButtonActionTimeout.TabIndex = 0;
            this.ctrlButtonActionTimeout.Text = "button2";
            this.ctrlButtonActionTimeout.UseVisualStyleBackColor = true;
            // 
            // ctrlPanelCurrentStep
            // 
            this.ctrlPanelCurrentStep.AutoSize = true;
            this.ctrlPanelCurrentStep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPanelCurrentStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPanelCurrentStep.Location = new System.Drawing.Point(0, 60);
            this.ctrlPanelCurrentStep.MaximumSize = new System.Drawing.Size(752, 580);
            this.ctrlPanelCurrentStep.MinimumSize = new System.Drawing.Size(752, 580);
            this.ctrlPanelCurrentStep.Name = "ctrlPanelCurrentStep";
            this.ctrlPanelCurrentStep.Size = new System.Drawing.Size(752, 580);
            this.ctrlPanelCurrentStep.TabIndex = 4;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 729);
            this.Controls.Add(this.ctrlPanelCurrentStep);
            this.Controls.Add(this.ctrlPanelHeader);
            this.Controls.Add(this.ctrlPanelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(768, 768);
            this.MinimumSize = new System.Drawing.Size(768, 768);
            this.Name = "BaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitProgram);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ctrlPanelTotalTimer.ResumeLayout(false);
            this.ctrlPanelHeader.ResumeLayout(false);
            this.ctrlPanelHeader.PerformLayout();
            this.ctrlPanelFooter.ResumeLayout(false);
            this.ctrlPanelActionTimer.ResumeLayout(false);
            this.ctrlPanelActionTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ctrlButtonProcessTimeout;
        private System.Windows.Forms.Button ctrlButtonActionTimeout;
    }
}


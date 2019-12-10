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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Header = new System.Windows.Forms.Label();
            this.panelTotalTimer = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_nextStep = new System.Windows.Forms.Button();
            this.btn_previousStep = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCurrentTimer = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(333, 21);
            this.lbl_Header.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(0, 36);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTotalTimer
            // 
            this.panelTotalTimer.AutoSize = true;
            this.panelTotalTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTotalTimer.BackColor = System.Drawing.Color.Lime;
            this.panelTotalTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotalTimer.Location = new System.Drawing.Point(0, 624);
            this.panelTotalTimer.Margin = new System.Windows.Forms.Padding(2);
            this.panelTotalTimer.MinimumSize = new System.Drawing.Size(0, 20);
            this.panelTotalTimer.Name = "panelTotalTimer";
            this.panelTotalTimer.Size = new System.Drawing.Size(863, 20);
            this.panelTotalTimer.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.AutoSize = true;
            this.panelHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHeader.BackColor = System.Drawing.Color.Gray;
            this.panelHeader.Controls.Add(this.lbl_Header);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.MinimumSize = new System.Drawing.Size(0, 60);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(863, 60);
            this.panelHeader.TabIndex = 3;
            // 
            // panelFooter
            // 
            this.panelFooter.AutoSize = true;
            this.panelFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFooter.BackColor = System.Drawing.Color.Blue;
            this.panelFooter.Controls.Add(this.btn_cancel);
            this.panelFooter.Controls.Add(this.btn_nextStep);
            this.panelFooter.Controls.Add(this.btn_previousStep);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 524);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(2);
            this.panelFooter.MinimumSize = new System.Drawing.Size(0, 80);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(863, 80);
            this.panelFooter.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Location = new System.Drawing.Point(670, 29);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Abbrechen";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_nextStep
            // 
            this.btn_nextStep.Location = new System.Drawing.Point(399, 29);
            this.btn_nextStep.Name = "btn_nextStep";
            this.btn_nextStep.Size = new System.Drawing.Size(75, 23);
            this.btn_nextStep.TabIndex = 1;
            this.btn_nextStep.Text = "Weiter";
            this.btn_nextStep.UseVisualStyleBackColor = true;
            this.btn_nextStep.Click += new System.EventHandler(this.btn_nextStep_Click);
            // 
            // btn_previousStep
            // 
            this.btn_previousStep.Enabled = false;
            this.btn_previousStep.Location = new System.Drawing.Point(135, 32);
            this.btn_previousStep.Name = "btn_previousStep";
            this.btn_previousStep.Size = new System.Drawing.Size(75, 23);
            this.btn_previousStep.TabIndex = 0;
            this.btn_previousStep.Text = "Zurück";
            this.btn_previousStep.UseVisualStyleBackColor = true;
            this.btn_previousStep.Click += new System.EventHandler(this.btn_previousStep_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(863, 464);
            this.panelMain.TabIndex = 4;
            // 
            // panelCurrentTimer
            // 
            this.panelCurrentTimer.AutoSize = true;
            this.panelCurrentTimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCurrentTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelCurrentTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCurrentTimer.Location = new System.Drawing.Point(0, 604);
            this.panelCurrentTimer.Margin = new System.Windows.Forms.Padding(2);
            this.panelCurrentTimer.MinimumSize = new System.Drawing.Size(0, 20);
            this.panelCurrentTimer.Name = "panelCurrentTimer";
            this.panelCurrentTimer.Size = new System.Drawing.Size(863, 20);
            this.panelCurrentTimer.TabIndex = 0;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 644);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelCurrentTimer);
            this.Controls.Add(this.panelTotalTimer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaseForm";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Panel panelTotalTimer;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_nextStep;
        private System.Windows.Forms.Button btn_previousStep;
        private System.Windows.Forms.Panel panelCurrentTimer;
    }
}


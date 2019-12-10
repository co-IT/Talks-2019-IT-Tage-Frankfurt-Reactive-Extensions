namespace SmartGateIn.ProcessSteps
{
    partial class ScanControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBox_ScannerStatus = new System.Windows.Forms.CheckBox();
            this.txtBox_Results = new System.Windows.Forms.TextBox();
            this.txtBox_Scanned = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 451);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ihre Abholinformationen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 451);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bisher gescannt";
            // 
            // chkBox_ScannerStatus
            // 
            this.chkBox_ScannerStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBox_ScannerStatus.BackColor = System.Drawing.Color.OrangeRed;
            this.chkBox_ScannerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_ScannerStatus.Location = new System.Drawing.Point(14, 499);
            this.chkBox_ScannerStatus.Margin = new System.Windows.Forms.Padding(2);
            this.chkBox_ScannerStatus.Name = "chkBox_ScannerStatus";
            this.chkBox_ScannerStatus.Size = new System.Drawing.Size(723, 79);
            this.chkBox_ScannerStatus.TabIndex = 7;
            this.chkBox_ScannerStatus.Text = "Scanner aktivieren";
            this.chkBox_ScannerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBox_ScannerStatus.UseVisualStyleBackColor = false;
            this.chkBox_ScannerStatus.CheckedChanged += new System.EventHandler(this.EnableDisableScanner);
            // 
            // txtBox_Results
            // 
            this.txtBox_Results.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBox_Results.Location = new System.Drawing.Point(401, 18);
            this.txtBox_Results.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_Results.Multiline = true;
            this.txtBox_Results.Name = "txtBox_Results";
            this.txtBox_Results.Size = new System.Drawing.Size(336, 418);
            this.txtBox_Results.TabIndex = 6;
            // 
            // txtBox_Scanned
            // 
            this.txtBox_Scanned.Location = new System.Drawing.Point(14, 18);
            this.txtBox_Scanned.Margin = new System.Windows.Forms.Padding(2);
            this.txtBox_Scanned.Multiline = true;
            this.txtBox_Scanned.Name = "txtBox_Scanned";
            this.txtBox_Scanned.Size = new System.Drawing.Size(336, 418);
            this.txtBox_Scanned.TabIndex = 4;
            // 
            // ScanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkBox_ScannerStatus);
            this.Controls.Add(this.txtBox_Results);
            this.Controls.Add(this.txtBox_Scanned);
            this.Name = "ScanControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBox_Scanned;
        private System.Windows.Forms.TextBox txtBox_Results;
        private System.Windows.Forms.CheckBox chkBox_ScannerStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

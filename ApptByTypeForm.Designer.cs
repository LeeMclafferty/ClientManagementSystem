
namespace ClientAppointmentManager
{
    partial class ApptByTypeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.LblType = new System.Windows.Forms.Label();
            this.LblMonth = new System.Windows.Forms.Label();
            this.CbMonth = new System.Windows.Forms.ComboBox();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(113, 125);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerate.TabIndex = 9;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(54, 87);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(31, 13);
            this.LblType.TabIndex = 8;
            this.LblType.Text = "Type";
            // 
            // LblMonth
            // 
            this.LblMonth.AutoSize = true;
            this.LblMonth.Location = new System.Drawing.Point(54, 50);
            this.LblMonth.Name = "LblMonth";
            this.LblMonth.Size = new System.Drawing.Size(37, 13);
            this.LblMonth.TabIndex = 7;
            this.LblMonth.Text = "Month";
            // 
            // CbMonth
            // 
            this.CbMonth.FormattingEnabled = true;
            this.CbMonth.Location = new System.Drawing.Point(95, 47);
            this.CbMonth.Name = "CbMonth";
            this.CbMonth.Size = new System.Drawing.Size(121, 21);
            this.CbMonth.TabIndex = 5;
            // 
            // CbType
            // 
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(95, 84);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 21);
            this.CbType.TabIndex = 6;
            // 
            // ApptByTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 195);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.LblMonth);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.CbMonth);
            this.Name = "ApptByTypeForm";
            this.Text = "Generate Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblMonth;
        private System.Windows.Forms.ComboBox CbMonth;
        private System.Windows.Forms.ComboBox CbType;
    }
}
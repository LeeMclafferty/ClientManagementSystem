
namespace ClientAppointmentManager
{
    partial class ApptByConsultant
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
            this.LblConsultantName = new System.Windows.Forms.Label();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.CbConsultants = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LblConsultantName
            // 
            this.LblConsultantName.AutoSize = true;
            this.LblConsultantName.Location = new System.Drawing.Point(22, 70);
            this.LblConsultantName.Name = "LblConsultantName";
            this.LblConsultantName.Size = new System.Drawing.Size(88, 13);
            this.LblConsultantName.TabIndex = 15;
            this.LblConsultantName.Text = "Consultant Name";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(103, 104);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerate.TabIndex = 13;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // CbConsultants
            // 
            this.CbConsultants.FormattingEnabled = true;
            this.CbConsultants.Location = new System.Drawing.Point(113, 66);
            this.CbConsultants.Name = "CbConsultants";
            this.CbConsultants.Size = new System.Drawing.Size(142, 21);
            this.CbConsultants.TabIndex = 0;
            // 
            // ApptByConsultant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 195);
            this.Controls.Add(this.CbConsultants);
            this.Controls.Add(this.LblConsultantName);
            this.Controls.Add(this.BtnGenerate);
            this.Name = "ApptByConsultant";
            this.Text = "ApptByConsultant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblConsultantName;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.ComboBox CbConsultants;
    }
}
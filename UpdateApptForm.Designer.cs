
namespace ClientAppointmentManager
{
    partial class UpdateApptForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.LblDateStart = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.DtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.LblType = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LblId = new System.Windows.Forms.Label();
            this.TbId = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TbClientName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "End Date and Time";
            // 
            // DtpTimeEnd
            // 
            this.DtpTimeEnd.Location = new System.Drawing.Point(40, 63);
            this.DtpTimeEnd.Name = "DtpTimeEnd";
            this.DtpTimeEnd.Size = new System.Drawing.Size(188, 20);
            this.DtpTimeEnd.TabIndex = 49;
            // 
            // LblDateStart
            // 
            this.LblDateStart.AutoSize = true;
            this.LblDateStart.Location = new System.Drawing.Point(81, 44);
            this.LblDateStart.Name = "LblDateStart";
            this.LblDateStart.Size = new System.Drawing.Size(102, 13);
            this.LblDateStart.TabIndex = 57;
            this.LblDateStart.Text = "Start Date and Time";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(86, 201);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdate.TabIndex = 53;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnSchedule_Click);
            // 
            // DtpTimeStart
            // 
            this.DtpTimeStart.Location = new System.Drawing.Point(40, 22);
            this.DtpTimeStart.Name = "DtpTimeStart";
            this.DtpTimeStart.Size = new System.Drawing.Size(192, 20);
            this.DtpTimeStart.TabIndex = 48;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(78, 172);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(93, 13);
            this.LblType.TabIndex = 56;
            this.LblType.Text = "Appointment Type";
            // 
            // CbType
            // 
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(64, 148);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 21);
            this.CbType.TabIndex = 52;
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(64, 130);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(18, 13);
            this.LblId.TabIndex = 55;
            this.LblId.Text = "ID";
            // 
            // TbId
            // 
            this.TbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TbId.Location = new System.Drawing.Point(40, 106);
            this.TbId.Name = "TbId";
            this.TbId.Size = new System.Drawing.Size(63, 21);
            this.TbId.TabIndex = 50;
            this.TbId.TextChanged += new System.EventHandler(this.TbId_TextChanged);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(142, 129);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(64, 13);
            this.LblName.TabIndex = 54;
            this.LblName.Text = "Client Name";
            // 
            // TbClientName
            // 
            this.TbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TbClientName.Location = new System.Drawing.Point(114, 106);
            this.TbClientName.Name = "TbClientName";
            this.TbClientName.Size = new System.Drawing.Size(118, 21);
            this.TbClientName.TabIndex = 51;
            this.TbClientName.TextChanged += new System.EventHandler(this.TbClientName_TextChanged);
            // 
            // UpdateApptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpTimeEnd);
            this.Controls.Add(this.LblDateStart);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.DtpTimeStart);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.TbId);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TbClientName);
            this.Name = "UpdateApptForm";
            this.Text = "UpdateApptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpTimeEnd;
        private System.Windows.Forms.Label LblDateStart;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.DateTimePicker DtpTimeStart;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.TextBox TbId;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbClientName;
    }
}
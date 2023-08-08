
namespace ClientAppointmentManager
{
    partial class AddApptForm
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
            this.LblName = new System.Windows.Forms.Label();
            this.TbClientName = new System.Windows.Forms.TextBox();
            this.TbId = new System.Windows.Forms.TextBox();
            this.LblId = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LblType = new System.Windows.Forms.Label();
            this.DtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.DtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.BtnSchedule = new System.Windows.Forms.Button();
            this.LblDateStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.DtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(146, 133);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(64, 13);
            this.LblName.TabIndex = 36;
            this.LblName.Text = "Client Name";
            // 
            // TbClientName
            // 
            this.TbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TbClientName.Location = new System.Drawing.Point(118, 110);
            this.TbClientName.Name = "TbClientName";
            this.TbClientName.Size = new System.Drawing.Size(118, 21);
            this.TbClientName.TabIndex = 5;
            this.TbClientName.TextChanged += new System.EventHandler(this.TbClientName_TextChanged);
            // 
            // TbId
            // 
            this.TbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TbId.Location = new System.Drawing.Point(44, 110);
            this.TbId.Name = "TbId";
            this.TbId.Size = new System.Drawing.Size(63, 21);
            this.TbId.TabIndex = 4;
            this.TbId.TextChanged += new System.EventHandler(this.TbId_TextChanged);
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(68, 134);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(18, 13);
            this.LblId.TabIndex = 38;
            this.LblId.Text = "ID";
            // 
            // CbType
            // 
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(68, 152);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 21);
            this.CbType.TabIndex = 6;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(82, 176);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(93, 13);
            this.LblType.TabIndex = 40;
            this.LblType.Text = "Appointment Type";
            // 
            // DtpDateStart
            // 
            this.DtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDateStart.Location = new System.Drawing.Point(36, 26);
            this.DtpDateStart.Name = "DtpDateStart";
            this.DtpDateStart.Size = new System.Drawing.Size(97, 20);
            this.DtpDateStart.TabIndex = 0;
            // 
            // DtpTimeStart
            // 
            this.DtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpTimeStart.Location = new System.Drawing.Point(139, 26);
            this.DtpTimeStart.Name = "DtpTimeStart";
            this.DtpTimeStart.Size = new System.Drawing.Size(97, 20);
            this.DtpTimeStart.TabIndex = 1;
            // 
            // BtnSchedule
            // 
            this.BtnSchedule.Location = new System.Drawing.Point(90, 205);
            this.BtnSchedule.Name = "BtnSchedule";
            this.BtnSchedule.Size = new System.Drawing.Size(75, 23);
            this.BtnSchedule.TabIndex = 7;
            this.BtnSchedule.Text = "Schedule";
            this.BtnSchedule.UseVisualStyleBackColor = true;
            this.BtnSchedule.Click += new System.EventHandler(this.BtnSchedule_Click);
            // 
            // LblDateStart
            // 
            this.LblDateStart.AutoSize = true;
            this.LblDateStart.Location = new System.Drawing.Point(85, 48);
            this.LblDateStart.Name = "LblDateStart";
            this.LblDateStart.Size = new System.Drawing.Size(102, 13);
            this.LblDateStart.TabIndex = 44;
            this.LblDateStart.Text = "Start Date and Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "End Date and Time";
            // 
            // DtpTimeEnd
            // 
            this.DtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpTimeEnd.Location = new System.Drawing.Point(135, 67);
            this.DtpTimeEnd.Name = "DtpTimeEnd";
            this.DtpTimeEnd.Size = new System.Drawing.Size(97, 20);
            this.DtpTimeEnd.TabIndex = 3;
            // 
            // DtpDateEnd
            // 
            this.DtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDateEnd.Location = new System.Drawing.Point(32, 67);
            this.DtpDateEnd.Name = "DtpDateEnd";
            this.DtpDateEnd.Size = new System.Drawing.Size(97, 20);
            this.DtpDateEnd.TabIndex = 2;
            // 
            // AddApptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpTimeEnd);
            this.Controls.Add(this.DtpDateEnd);
            this.Controls.Add(this.LblDateStart);
            this.Controls.Add(this.BtnSchedule);
            this.Controls.Add(this.DtpTimeStart);
            this.Controls.Add(this.DtpDateStart);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.TbId);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TbClientName);
            this.Name = "AddApptForm";
            this.Text = "New Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbClientName;
        private System.Windows.Forms.TextBox TbId;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.DateTimePicker DtpDateStart;
        private System.Windows.Forms.DateTimePicker DtpTimeStart;
        private System.Windows.Forms.Button BtnSchedule;
        private System.Windows.Forms.Label LblDateStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpTimeEnd;
        private System.Windows.Forms.DateTimePicker DtpDateEnd;
    }
}
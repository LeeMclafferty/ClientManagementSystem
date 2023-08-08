
namespace ClientAppointmentManager
{
    partial class HubForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.DgvClients = new System.Windows.Forms.DataGridView();
            this.DgvReports = new System.Windows.Forms.DataGridView();
            this.DgvCalendar = new System.Windows.Forms.DataGridView();
            this.DtpStart = new System.Windows.Forms.DateTimePicker();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnRange = new System.Windows.Forms.Button();
            this.BtnAll = new System.Windows.Forms.Button();
            this.LblReport = new System.Windows.Forms.Label();
            this.BtnApptClient = new System.Windows.Forms.Button();
            this.BtnApptType = new System.Windows.Forms.Button();
            this.BtnConsultant = new System.Windows.Forms.Button();
            this.LblAppointments = new System.Windows.Forms.Label();
            this.LblClients = new System.Windows.Forms.Label();
            this.BtnNewAppt = new System.Windows.Forms.Button();
            this.LblApptFound = new System.Windows.Forms.Label();
            this.LbLTotalNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 319);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(310, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(568, 319);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(12, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(866, 274);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // DgvClients
            // 
            this.DgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClients.Location = new System.Drawing.Point(330, 34);
            this.DgvClients.Name = "DgvClients";
            this.DgvClients.Size = new System.Drawing.Size(528, 256);
            this.DgvClients.TabIndex = 3;
            // 
            // DgvReports
            // 
            this.DgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReports.Location = new System.Drawing.Point(330, 381);
            this.DgvReports.Name = "DgvReports";
            this.DgvReports.Size = new System.Drawing.Size(528, 221);
            this.DgvReports.TabIndex = 4;
            // 
            // DgvCalendar
            // 
            this.DgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCalendar.Location = new System.Drawing.Point(51, 34);
            this.DgvCalendar.Name = "DgvCalendar";
            this.DgvCalendar.Size = new System.Drawing.Size(213, 186);
            this.DgvCalendar.TabIndex = 5;
            // 
            // DtpStart
            // 
            this.DtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpStart.Location = new System.Drawing.Point(51, 226);
            this.DtpStart.Name = "DtpStart";
            this.DtpStart.Size = new System.Drawing.Size(81, 20);
            this.DtpStart.TabIndex = 6;
            // 
            // DtpEnd
            // 
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpEnd.Location = new System.Drawing.Point(182, 226);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(81, 20);
            this.DtpEnd.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "to";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(350, 296);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(131, 23);
            this.BtnUpdate.TabIndex = 9;
            this.BtnUpdate.Text = "Update Client";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(529, 296);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(131, 23);
            this.BtnAdd.TabIndex = 10;
            this.BtnAdd.Text = "Add Client";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(708, 296);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(131, 23);
            this.BtnRemove.TabIndex = 11;
            this.BtnRemove.Text = "Remove Client";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnRange
            // 
            this.BtnRange.Location = new System.Drawing.Point(51, 250);
            this.BtnRange.Name = "BtnRange";
            this.BtnRange.Size = new System.Drawing.Size(98, 23);
            this.BtnRange.TabIndex = 12;
            this.BtnRange.Text = "Show Range";
            this.BtnRange.UseVisualStyleBackColor = true;
            this.BtnRange.Click += new System.EventHandler(this.BtnRange_Click);
            // 
            // BtnAll
            // 
            this.BtnAll.Location = new System.Drawing.Point(166, 250);
            this.BtnAll.Name = "BtnAll";
            this.BtnAll.Size = new System.Drawing.Size(98, 23);
            this.BtnAll.TabIndex = 13;
            this.BtnAll.Text = "Show All";
            this.BtnAll.UseVisualStyleBackColor = true;
            this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // LblReport
            // 
            this.LblReport.AutoSize = true;
            this.LblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblReport.Location = new System.Drawing.Point(116, 366);
            this.LblReport.Name = "LblReport";
            this.LblReport.Size = new System.Drawing.Size(115, 17);
            this.LblReport.TabIndex = 14;
            this.LblReport.Text = "Generate Report";
            // 
            // BtnApptClient
            // 
            this.BtnApptClient.Location = new System.Drawing.Point(51, 466);
            this.BtnApptClient.Name = "BtnApptClient";
            this.BtnApptClient.Size = new System.Drawing.Size(212, 23);
            this.BtnApptClient.TabIndex = 16;
            this.BtnApptClient.Text = "Appointment By Client";
            this.BtnApptClient.UseVisualStyleBackColor = true;
            this.BtnApptClient.Click += new System.EventHandler(this.BtnApptClient_Click);
            // 
            // BtnApptType
            // 
            this.BtnApptType.Location = new System.Drawing.Point(52, 411);
            this.BtnApptType.Name = "BtnApptType";
            this.BtnApptType.Size = new System.Drawing.Size(212, 23);
            this.BtnApptType.TabIndex = 15;
            this.BtnApptType.Text = "Appointment By Type";
            this.BtnApptType.UseVisualStyleBackColor = true;
            this.BtnApptType.Click += new System.EventHandler(this.BtnApptType_Click);
            // 
            // BtnConsultant
            // 
            this.BtnConsultant.Location = new System.Drawing.Point(51, 521);
            this.BtnConsultant.Name = "BtnConsultant";
            this.BtnConsultant.Size = new System.Drawing.Size(212, 23);
            this.BtnConsultant.TabIndex = 17;
            this.BtnConsultant.Text = "Consultant Schedule";
            this.BtnConsultant.UseVisualStyleBackColor = true;
            this.BtnConsultant.Click += new System.EventHandler(this.BtnConsultant_Click);
            // 
            // LblAppointments
            // 
            this.LblAppointments.AutoSize = true;
            this.LblAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblAppointments.Location = new System.Drawing.Point(112, 15);
            this.LblAppointments.Name = "LblAppointments";
            this.LblAppointments.Size = new System.Drawing.Size(94, 17);
            this.LblAppointments.TabIndex = 18;
            this.LblAppointments.Text = "Appointments";
            // 
            // LblClients
            // 
            this.LblClients.AutoSize = true;
            this.LblClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblClients.Location = new System.Drawing.Point(572, 15);
            this.LblClients.Name = "LblClients";
            this.LblClients.Size = new System.Drawing.Size(50, 17);
            this.LblClients.TabIndex = 19;
            this.LblClients.Text = "Clients";
            // 
            // BtnNewAppt
            // 
            this.BtnNewAppt.Location = new System.Drawing.Point(51, 279);
            this.BtnNewAppt.Name = "BtnNewAppt";
            this.BtnNewAppt.Size = new System.Drawing.Size(213, 23);
            this.BtnNewAppt.TabIndex = 20;
            this.BtnNewAppt.Text = "Schedule New Appointment";
            this.BtnNewAppt.UseVisualStyleBackColor = true;
            this.BtnNewAppt.Click += new System.EventHandler(this.BtnNewAppt_Click);
            // 
            // LblApptFound
            // 
            this.LblApptFound.AutoSize = true;
            this.LblApptFound.Location = new System.Drawing.Point(330, 362);
            this.LblApptFound.Name = "LblApptFound";
            this.LblApptFound.Size = new System.Drawing.Size(131, 13);
            this.LblApptFound.TabIndex = 21;
            this.LblApptFound.Text = "Total Appoinments Found:";
            // 
            // LbLTotalNum
            // 
            this.LbLTotalNum.AutoSize = true;
            this.LbLTotalNum.Location = new System.Drawing.Point(460, 362);
            this.LbLTotalNum.Name = "LbLTotalNum";
            this.LbLTotalNum.Size = new System.Drawing.Size(13, 13);
            this.LbLTotalNum.TabIndex = 22;
            this.LbLTotalNum.Text = "0";
            // 
            // HubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 620);
            this.Controls.Add(this.LbLTotalNum);
            this.Controls.Add(this.LblApptFound);
            this.Controls.Add(this.BtnNewAppt);
            this.Controls.Add(this.LblClients);
            this.Controls.Add(this.LblAppointments);
            this.Controls.Add(this.BtnConsultant);
            this.Controls.Add(this.BtnApptClient);
            this.Controls.Add(this.BtnApptType);
            this.Controls.Add(this.LblReport);
            this.Controls.Add(this.BtnAll);
            this.Controls.Add(this.BtnRange);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpEnd);
            this.Controls.Add(this.DtpStart);
            this.Controls.Add(this.DgvCalendar);
            this.Controls.Add(this.DgvReports);
            this.Controls.Add(this.DgvClients);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HubForm";
            this.Text = "Client Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView DgvClients;
        private System.Windows.Forms.DataGridView DgvReports;
        private System.Windows.Forms.DataGridView DgvCalendar;
        private System.Windows.Forms.DateTimePicker DtpStart;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnRange;
        private System.Windows.Forms.Button BtnAll;
        private System.Windows.Forms.Label LblReport;
        private System.Windows.Forms.Button BtnApptClient;
        private System.Windows.Forms.Button BtnApptType;
        private System.Windows.Forms.Button BtnConsultant;
        private System.Windows.Forms.Label LblAppointments;
        private System.Windows.Forms.Label LblClients;
        private System.Windows.Forms.Button BtnNewAppt;
        private System.Windows.Forms.Label LblApptFound;
        private System.Windows.Forms.Label LbLTotalNum;
    }
}
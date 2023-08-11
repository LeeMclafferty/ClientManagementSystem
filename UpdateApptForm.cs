using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAppointmentManager.src.Appointment;
using MySql.Data.MySqlClient;

namespace ClientAppointmentManager
{
    public partial class UpdateApptForm : Form
    {

        private HubForm parent;
        private Appointment originalAppointment;
        private Appointment updatedAppointment = new Appointment();
        public UpdateApptForm(HubForm form, Appointment appt)
        {
            InitializeComponent();
            parent = form;
            originalAppointment = appt;
            FillForm();
            SetAppointmentTypes();
        }

        private void FillForm()
        {

            // Set the format for the DateTimePickers
            DtpTimeStart.Value = originalAppointment.timeStart;
            DtpTimeEnd.Value = originalAppointment.timeEnd;

            DtpTimeStart.CustomFormat = "MM/dd/yyyy h:mm tt";
            DtpTimeEnd.CustomFormat = "MM/dd/yyyy h:mm tt";

            DtpTimeStart.Format = DateTimePickerFormat.Custom;
            DtpTimeEnd.Format = DateTimePickerFormat.Custom;

            // Fill the TbId and CbType
            TbId.Text = originalAppointment.customerId;
            CbType.Text = originalAppointment.type;
        }

        private void SetAppointmentTypes()
        {
            CbType.Items.Add("Scrum");
            CbType.Items.Add("Presentation");
            CbType.Items.Add("Consultation");
            CbType.Items.Add("Coaching");
        }

        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            if(CanUpdate())
            {
                SetUpdateAppoinment();
                originalAppointment.Update(parent.currentUser, updatedAppointment);
                parent.RefreshCalendarDgv();
                Close();
            }
        }

        private bool CanUpdate()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            if (string.IsNullOrWhiteSpace(TbId.Text) ||
                string.IsNullOrWhiteSpace(TbClientName.Text) ||
                string.IsNullOrWhiteSpace(CbType.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            // Check End date / time comes after start date / time
            DateTime startDateTime = DtpTimeStart.Value.Date + DtpTimeStart.Value.TimeOfDay;
            DateTime endDateTime = DtpTimeEnd.Value.Date + DtpTimeEnd.Value.TimeOfDay;

            if (endDateTime <= startDateTime)
            {
                MessageBox.Show("End time must come after start time.");
                return false;
            }

            if (DtpTimeStart.Value.Hour < 9 || (DtpTimeStart.Value.Hour == 16 && DtpTimeStart.Value.Minute > 0) ||
                DtpTimeEnd.Value.Hour < 9 || (DtpTimeEnd.Value.Hour == 17 && DtpTimeEnd.Value.Minute > 0))
            {
                MessageBox.Show("Appointments should be scheduled between 9 AM to 5 PM.");
                return false;
            }

            // Check for overlapping appointments for the currentUser in the appointment table
            string userIdQuery = "SELECT userId FROM user WHERE userName = @userName";
            MySqlCommand cmdUserId = new MySqlCommand(userIdQuery, conn);
            cmdUserId.Parameters.AddWithValue("@userName", parent.currentUser);

            object result = cmdUserId.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Invalid User Name.");
                return false;
            }
            int userId = Convert.ToInt32(result);

            string overlapCheck = @"
            SELECT COUNT(*) FROM appointment 
            WHERE ((start <= @start AND end > @start) OR 
                   (start < @end AND end >= @end) OR 
                   (start >= @start AND end <= @end)) 
            AND userId = @userId";

            MySqlCommand cmdOverlap = new MySqlCommand(overlapCheck, conn);
            cmdOverlap.Parameters.AddWithValue("@start", startDateTime);
            cmdOverlap.Parameters.AddWithValue("@end", endDateTime);
            cmdOverlap.Parameters.AddWithValue("@userId", userId);

            int overlapCount = Convert.ToInt32(cmdOverlap.ExecuteScalar());
            if (overlapCount > 0)
            {
                MessageBox.Show("There are overlapping appointments. Please choose a different time slot.");
                return false;
            }

            if (!IsValidUserId(parent.currentUserId))
            {
                MessageBox.Show("Invalid User ID.");
                return false;
            }

            return true;
        }

        private bool IsValidUserId(string id)
        {
            int userId;
            if (!int.TryParse(id, out userId))
            {
                // userIdText is not a valid integer
                return false;
            }

            MySqlConnection conn = src.Database.DbConnection.conn;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string query = "SELECT COUNT(*) FROM user WHERE userId = @userId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }


        string GetCustNameFromId()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string query = "SELECT customerName FROM customer WHERE customerId = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", TbId.Text);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return "";
            }
        }

        string GetCustomerIdFromName()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string query = "SELECT customerId FROM customer WHERE customerName = @name";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", TbClientName.Text);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return "";
            }
        }

        private void TbId_TextChanged(object sender, EventArgs e)
        {
            TbClientName.Text = GetCustNameFromId();
        }

        private void TbClientName_TextChanged(object sender, EventArgs e)
        {
            TbId.Text = GetCustomerIdFromName();
        }

        private void SetUpdateAppoinment()
        {
            updatedAppointment.customerId = TbId.Text;
            updatedAppointment.customerName = TbClientName.Text;
            updatedAppointment.timeStart = DtpTimeStart.Value;
            updatedAppointment.timeEnd = DtpTimeEnd.Value;
            updatedAppointment.type = CbType.Text;
        }
    }
}

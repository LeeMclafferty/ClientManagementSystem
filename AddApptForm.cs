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
    public partial class AddApptForm : Form
    {
        Appointment appt = new Appointment();
        HubForm parentForm;
        public AddApptForm(HubForm parent)
        {
            InitializeComponent();
            SetAppointmentTypes();
            parentForm = parent;
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
            if (!CanSchedule())
                return;

            appt.customerId = TbId.Text;
            appt.customerName = TbClientName.Text;
            appt.dateStart = DtpDateStart.Value;
            appt.timeStart = DtpTimeStart.Value;
            appt.dateEnd = DtpDateEnd.Value;
            appt.timeEnd = DtpTimeEnd.Value;
            appt.type = CbType.Text;

            appt.Schedule(parentForm.currentUserId, parentForm.currentUser);
            parentForm.RefreshCalendarDgv();
            Close();
        }

        private bool CanSchedule()
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
            DateTime startDateTime = DtpDateStart.Value.Date + DtpTimeStart.Value.TimeOfDay;
            DateTime endDateTime = DtpDateEnd.Value.Date + DtpTimeEnd.Value.TimeOfDay;

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
            cmdUserId.Parameters.AddWithValue("@userName", parentForm.currentUser);

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

            if (!IsValidUserId(parentForm.currentUserId))
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

        private void TbClientName_TextChanged(object sender, EventArgs e)
        {
            TbId.Text = GetCustomerIdFromName().ToString();
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

        private void TbId_TextChanged(object sender, EventArgs e)
        {
            TbClientName.Text = GetCustNameFromId();
        }
    }
}

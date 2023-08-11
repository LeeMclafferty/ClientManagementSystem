using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClientAppointmentManager
{
    public partial class ApptByConsultant : Form
    {
        HubForm parent;
        public ApptByConsultant(HubForm form)
        {
            InitializeComponent();
            parent = form;
            SetupConsultants();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (CbConsultants.SelectedItem == null)
            {
                MessageBox.Show("Please select a consultant.");
                return;
            }

            string consultantName = CbConsultants.SelectedItem.ToString();

            string query = @"
        SELECT user.userName, appointment.type, customer.customerName, appointment.start, appointment.end 
        FROM appointment 
        JOIN user ON appointment.userId = user.userId
        JOIN customer ON appointment.customerId = customer.customerId
        WHERE user.userName = @consultantName";

            MySqlConnection conn = src.Database.DbConnection.conn;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@consultantName", consultantName);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found for the specified consultant.");
                return;
            }

            int numApptFound = dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                DateTime startValue = (DateTime)row["start"];
                DateTime endValue = (DateTime)row["end"];

                Console.WriteLine($"Start: {startValue}, End: {endValue}");

                row["start"] = startValue.ToLocalTime();
                row["end"] = endValue.ToLocalTime();
            }

            parent.DgvBuffer.DataSource = dt;
            parent.SetReportDgv();
            parent.SetTotalNumLbl(numApptFound);
            parent.SetConsultantReportHeaders();
            Close();
        }



        private void SetupConsultants()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string query = "SELECT userName FROM user ORDER BY userName ASC";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                CbConsultants.Items.Clear();

                while (reader.Read())
                {
                    CbConsultants.Items.Add(reader["userName"].ToString());
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}

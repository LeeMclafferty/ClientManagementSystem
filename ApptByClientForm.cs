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
    public partial class ApptByClientForm : Form
    {
        HubForm parent;
        public ApptByClientForm(HubForm form)
        {
            InitializeComponent();
            parent = form;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbClient.Text))
            {
                MessageBox.Show("Please enter a client name.");
                return;
            }

            string clientName = TbClient.Text;

            string query = @"
            SELECT customer.customerName, appointment.type, appointment.start, appointment.end 
            FROM appointment 
            JOIN customer ON appointment.customerId = customer.customerId
            WHERE customer.customerName = @clientName";

            MySqlConnection conn = src.Database.DbConnection.conn;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clientName", clientName);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found for the specified client.");
                return;
            }

            int numApptFound = dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                row["start"] = DateTime.SpecifyKind(Convert.ToDateTime(row["start"]), DateTimeKind.Utc).ToLocalTime();
                row["end"] = DateTime.SpecifyKind(Convert.ToDateTime(row["end"]), DateTimeKind.Utc).ToLocalTime();
            }

            parent.DgvBuffer.DataSource = dt;
            parent.SetReportDgv();
            parent.SetTotalNumLbl(numApptFound);
            parent.SetClientReportHeaders();
            Close();
            //MessageBox.Show($"{numApptFound} appointment(s) found for the client {clientName}.");
        }

    }
}

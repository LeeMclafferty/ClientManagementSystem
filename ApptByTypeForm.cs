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
    public partial class ApptByTypeForm : Form
    {
        public HubForm parent;
        public ApptByTypeForm(HubForm form)
        {
            InitializeComponent();
            parent = form;
            SetTypes();
            SetMonths();
        }

        private void SetTypes()
        {
            CbType.Items.Add("Scrum");
            CbType.Items.Add("Presentation");
            CbType.Items.Add("Consultation");
            CbType.Items.Add("Coaching");
        }

        private void SetMonths()
        {
            CbMonth.Items.Add("January");
            CbMonth.Items.Add("February");
            CbMonth.Items.Add("March");
            CbMonth.Items.Add("April");
            CbMonth.Items.Add("May");
            CbMonth.Items.Add("June");
            CbMonth.Items.Add("July");
            CbMonth.Items.Add("August");
            CbMonth.Items.Add("September");
            CbMonth.Items.Add("October");
            CbMonth.Items.Add("November");
            CbMonth.Items.Add("December");

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (CbType.SelectedItem == null || CbMonth.SelectedItem == null)
            {
                MessageBox.Show("Please select both a type and a month.");
                return;
            }

            string selectedType = CbType.SelectedItem.ToString();
            int selectedMonth = CbMonth.SelectedIndex + 1;

            // Construct SQL query
            string query = @"
                SELECT customer.customerName, appointment.type ,appointment.start, appointment.end 
                FROM appointment 
                JOIN customer ON appointment.customerId = customer.customerId
                WHERE appointment.type = @type 
                AND MONTH(appointment.start) = @month";  

            MySqlConnection conn = src.Database.DbConnection.conn;
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@type", selectedType);
            cmd.Parameters.AddWithValue("@month", selectedMonth);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            parent.DgvBuffer.DataSource = dt;
            parent.SetTotalNumLbl(GetTotalAppointments(selectedType, selectedMonth));
            parent.SetReportDgv();
            parent.SetTypeReportHeaders();
            Close();
        }
        private int GetTotalAppointments(string type, int month)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM appointment 
            WHERE type = @type 
            AND MONTH(start) = @month";

            MySqlConnection conn = src.Database.DbConnection.conn;
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@month", month);

            object result = cmd.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count;
            }

            return 0; 
        }

    }
}

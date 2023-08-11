using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClientAppointmentManager.src.Database;
using ClientAppointmentManager.src.Client;
using System.Text.RegularExpressions;
using ClientAppointmentManager.src.Appointment;

namespace ClientAppointmentManager
{
    public partial class HubForm : Form
    {
        Form1 loginForm;
        public string currentUser { get; set; }
        public string currentUserId { get; set; }
        public DataGridView DgvBuffer = new DataGridView();
        public HubForm(Form1 login, string user)
        {
            InitializeComponent();
            loginForm = login;
            currentUser = user;
            currentUserId = GetCurrentUserId().ToString();
            RefreshClientDgv();
            RefreshCalendarDgv();
            DgvClients.AllowUserToAddRows = false;
            DgvCalendar.AllowUserToDeleteRows = false;
            DgvReports.AllowUserToAddRows = false;
            SetDgvHeaders();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            loginForm.Close();
            Application.Exit();
        }

        private void SetDgvHeaders()
        {
            DgvClients.Columns["customerId"].HeaderText = "ID";
            DgvClients.Columns["customerName"].HeaderText = "Customer Name";
            DgvClients.Columns["phone"].HeaderText = "Phone";
            DgvClients.Columns["address"].HeaderText = "Address";
            DgvClients.Columns["address2"].HeaderText = "Address2";
            DgvClients.Columns["postalCode"].HeaderText = "Postal";
            DgvClients.Columns["city"].HeaderText = "City";
            DgvClients.Columns["country"].HeaderText = "Country";

            DgvCalendar.Columns["customerId"].HeaderText = "ID";
            DgvCalendar.Columns["customerName"].HeaderText = "Customer Name";
            DgvCalendar.Columns["type"].HeaderText = "Type";
            DgvCalendar.Columns["start"].HeaderText = "Start";
            DgvCalendar.Columns["end"].HeaderText = "End";

            /*DgvReports.Columns["customerName"].HeaderText = "Customer Name";
            DgvReports.Columns["start"].HeaderText = "Start Date & Time";
            DgvReports.Columns["end"].HeaderText = "End Date & Time";

            DgvReports.Columns["start"].DefaultCellStyle.Format = "g";
            DgvReports.Columns["end"].DefaultCellStyle.Format = "g";*/
        }

        public void RefreshClientDgv()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "SELECT " +
                "customer.customerId," +
                "customer.customerName, " +
                "address.phone," +
                "address.address, " +
                "address.address2," +
                "address.postalCode," +
                "city.city, " +
                "country.country " +
                "FROM customer " +
                "JOIN address ON customer.addressId = address.addressId " +
                "JOIN city ON address.cityId = city.cityId " +
                "JOIN country on city.countryId = country.countryId", conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DgvClients.DataSource = dt;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (DgvClients.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure that you want to delete this customer and all related data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = src.Database.DbConnection.conn;

                    string customerId = DgvClients.SelectedRows[0].Cells["customerId"].Value.ToString();

                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId";
                        MySqlCommand deleteAppointmentsCommand = new MySqlCommand(deleteAppointmentsQuery, conn);
                        deleteAppointmentsCommand.Parameters.AddWithValue("@customerId", customerId);
                        deleteAppointmentsCommand.Transaction = transaction; 
                        deleteAppointmentsCommand.ExecuteNonQuery();

                        string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId";
                        MySqlCommand deleteCustomerCommand = new MySqlCommand(deleteCustomerQuery, conn);
                        deleteCustomerCommand.Parameters.AddWithValue("@customerId", customerId);
                        deleteCustomerCommand.Transaction = transaction; 
                        deleteCustomerCommand.ExecuteNonQuery();

                        transaction.Commit();

                        RefreshClientDgv();
                        RefreshCalendarDgv();
                        MessageBox.Show("Customer and all related data deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        // If anything goes wrong, roll back the transaction to leave the database in a consistent state
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddClientForm addForm = new AddClientForm(this);
            addForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DgvClients.SelectedRows.Count <= 0 || DgvClients.SelectedRows.Count > 1)
            {
                MessageBox.Show("You must select a single row to update.");
                return;
            }
            else
            {
                DataGridViewRow row = DgvClients.SelectedRows[0];
                Client client = new Client(
                    row.Cells["customerName"].Value.ToString(),
                    row.Cells["address"].Value.ToString(), row.Cells["address2"].Value.ToString(), row.Cells["postalCode"].Value.ToString(),
                    row.Cells["phone"].Value.ToString(),
                    row.Cells["city"].Value.ToString(), row.Cells["country"].Value.ToString()
                );
                SetClientIds(row, client);
                //MessageBox.Show(client.ids.customerId);
                UpdateClient updateForm = new UpdateClient(this, client);
                updateForm.Show();
            }
        }

        private void SetClientIds(DataGridViewRow row, Client cust)
        {
            if (cust == null) return;

            MySqlConnection conn = src.Database.DbConnection.conn;

            string query = @"SELECT customerId FROM customer WHERE customerName = @param";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@param", cust.name);
            object result = command.ExecuteScalar();
            cust.ids.customerId = result.ToString();

            query = @"SELECT addressId FROM address WHERE address = @param";
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@param", cust.fullAddress.address);
            result = command.ExecuteScalar();
            cust.ids.addressId = result.ToString();

            query = @"SELECT cityId FROM city WHERE city = @param";
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@param", cust.cityName);
            result = command.ExecuteScalar();
            cust.ids.cityId = result.ToString();

            query = @"SELECT countryId FROM country WHERE country = @param";
            command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@param", cust.countryName);
            result = command.ExecuteScalar();
            cust.ids.countryId = result.ToString();
        }
        public void RefreshCalendarDgv()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string query = @"
                SELECT 
                customer.customerId,
                customer.customerName,
                appointment.type,
                appointment.start AS utcStart,
                appointment.end AS utcEnd
                FROM appointment 
                JOIN customer ON appointment.customerId = customer.customerId";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                row["utcStart"] = DateTime.SpecifyKind((DateTime)row["utcStart"], DateTimeKind.Utc).ToLocalTime();
                row["utcEnd"] = DateTime.SpecifyKind((DateTime)row["utcEnd"], DateTimeKind.Utc).ToLocalTime();
            }


            Action<string, string> renameColumn = (oldName, newName) => dt.Columns[oldName].ColumnName = newName;
            renameColumn("utcStart", "start");
            renameColumn("utcEnd", "end");

            DgvCalendar.DataSource = dt;
            DgvCalendar.Columns["start"].DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";
            DgvCalendar.Columns["end"].DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";

            foreach (DataGridViewColumn column in DgvCalendar.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void BtnRange_Click(object sender, EventArgs e)
        {
            if (DtpStart.Value.Date > DtpEnd.Value.Date)
            {
                MessageBox.Show("The start date has to come before the end date.");
            }

            MySqlConnection conn = src.Database.DbConnection.conn;

            string query =
                "SELECT " +
                "customer.customerName, " +
                "appointment.type, appointment.start, appointment.end " +
                "FROM appointment " +
                "JOIN customer ON appointment.customerId = customer.customerId " +
                "WHERE appointment.start >= @start AND appointment.end <= @end";

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@start", DtpStart.Value.Date);
            command.Parameters.AddWithValue("@end", DtpEnd.Value.Date.AddDays(1).AddSeconds(-1));

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);

            DgvCalendar.DataSource = dt;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            RefreshCalendarDgv();
        }

        public void AddCustomer(Client client)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string countryQuery = @"
                INSERT INTO country (country, createdBy, createDate, lastUpdate, lastUpdateBy) 
                VALUES (@countryName, @createdBy, NOW(), NOW(),@lastUpdateBy) 
                ON DUPLICATE KEY UPDATE 
                countryId=LAST_INSERT_ID(countryId),
                lastUpdate=NOW(), 
                lastUpdateBy=@lastUpdateBy";

            MySqlCommand cmdCountry = new MySqlCommand(countryQuery, conn);
            cmdCountry.Parameters.AddWithValue("@countryName", client.countryName);
            cmdCountry.Parameters.AddWithValue("@createdBy", currentUser);
            cmdCountry.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCountry.ExecuteNonQuery();
            long countryId = cmdCountry.LastInsertedId;

            string cityQuery = @"
                INSERT INTO city (city, countryId, createdBy, createDate, lastUpdate, lastUpdateBy) 
                VALUES (@cityName, @countryId, @createdBy, NOW(), NOW(),@lastUpdateBy) 
                ON DUPLICATE KEY UPDATE 
                cityId=LAST_INSERT_ID(cityId), 
                lastUpdate=NOW(), 
                lastUpdateBy=@lastUpdateBy";

            MySqlCommand cmdCity = new MySqlCommand(cityQuery, conn);
            cmdCity.Parameters.AddWithValue("@cityName", client.cityName);
            cmdCity.Parameters.AddWithValue("@countryId", countryId);
            cmdCity.Parameters.AddWithValue("@createdBy", currentUser);
            cmdCity.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCity.ExecuteNonQuery();
            long cityId = cmdCity.LastInsertedId;

            string addressQuery = @"
                INSERT INTO address (address, address2, cityId, postalCode, phone, createdBy, createDate, lastUpdate, lastUpdateBy) 
                VALUES (@addressDetails, @address2, @cityId, @zip, @phoneNum,@createdBy, NOW(), NOW(), @lastUpdateBy) 
                ON DUPLICATE KEY UPDATE 
                addressId=LAST_INSERT_ID(addressId), 
                lastUpdate=NOW(), 
                lastUpdateBy=@lastUpdateBy";

            MySqlCommand cmdAddress = new MySqlCommand(addressQuery, conn);
            cmdAddress.Parameters.AddWithValue("@addressDetails", client.GetAddress().address);
            cmdAddress.Parameters.AddWithValue("@address2", client.GetAddress().address2);
            cmdAddress.Parameters.AddWithValue("@zip", client.GetAddress().postalCode);
            cmdAddress.Parameters.AddWithValue("@phoneNum", client.phoneNum);
            cmdAddress.Parameters.AddWithValue("@cityId", cityId);
            cmdAddress.Parameters.AddWithValue("@createdBy", currentUser);
            cmdAddress.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdAddress.ExecuteNonQuery();
            long addressId = cmdAddress.LastInsertedId;

            string customerQuery = @"
                INSERT INTO customer (customerName, addressId, active, createdBy, createDate, lastUpdate, lastUpdateBy) 
                VALUES (@customerName, @addressId, @act, @createdBy, NOW(), NOW(),@lastUpdateBy) 
                ON DUPLICATE KEY UPDATE 
                customerName=@customerName, 
                lastUpdate=NOW(), 
                lastUpdateBy=@lastUpdateBy";

            MySqlCommand cmdCustomer = new MySqlCommand(customerQuery, conn);
            cmdCustomer.Parameters.AddWithValue("@customerName", client.name);
            cmdCustomer.Parameters.AddWithValue("@addressId", addressId);
            cmdCustomer.Parameters.AddWithValue("@act", 1);
            cmdCustomer.Parameters.AddWithValue("@createdBy", currentUser);
            cmdCustomer.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCustomer.ExecuteNonQuery();

            RefreshClientDgv();
        }

        public void UpdateCustomer(Client client)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            string countryQuery = @"
                UPDATE country 
                SET country = @countryName, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                WHERE countryId = @countryId";

            MySqlCommand cmdCountry = new MySqlCommand(countryQuery, conn);
            cmdCountry.Parameters.AddWithValue("@countryName", client.countryName);
            cmdCountry.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCountry.Parameters.AddWithValue("@countryId", client.ids.countryId); 
            cmdCountry.ExecuteNonQuery();

            string cityQuery = @"
                UPDATE city 
                SET city = @cityName, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                WHERE cityId = @cityId";

            MySqlCommand cmdCity = new MySqlCommand(cityQuery, conn);
            cmdCity.Parameters.AddWithValue("@cityName", client.cityName);
            cmdCity.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCity.Parameters.AddWithValue("@cityId", client.ids.cityId); 
            cmdCity.ExecuteNonQuery();

            string addressQuery = @"
                UPDATE address 
                SET address = @addressDetails, address2 = @address2, postalCode = @zip, phone = @phoneNum, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                WHERE addressId = @addressId";

            MySqlCommand cmdAddress = new MySqlCommand(addressQuery, conn);
            cmdAddress.Parameters.AddWithValue("@addressDetails", client.GetAddress().address);
            cmdAddress.Parameters.AddWithValue("@address2", client.GetAddress().address2);
            cmdAddress.Parameters.AddWithValue("@zip", client.GetAddress().postalCode);
            cmdAddress.Parameters.AddWithValue("@phoneNum", client.phoneNum);
            cmdAddress.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdAddress.Parameters.AddWithValue("@addressId", client.ids.addressId);
            cmdAddress.ExecuteNonQuery();

            string customerQuery = @"
                UPDATE customer 
                SET customerName = @customerName, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy 
                WHERE customerId = @customerId";

            MySqlCommand cmdCustomer = new MySqlCommand(customerQuery, conn);
            cmdCustomer.Parameters.AddWithValue("@customerName", client.name);
            cmdCustomer.Parameters.AddWithValue("@lastUpdateBy", currentUser);
            cmdCustomer.Parameters.AddWithValue("@customerId", client.ids.customerId);  
            cmdCustomer.ExecuteNonQuery();

            RefreshClientDgv();
            RefreshCalendarDgv();
        }

        private void BtnNewAppt_Click(object sender, EventArgs e)
        {
            AddApptForm apptForm = new AddApptForm(this);
            apptForm.Show();
        }

        public int GetCurrentUserId()
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            if (conn == null)
            {
                throw new InvalidOperationException("Database connection is null.");
            }

            string query = "SELECT userId FROM user WHERE userName = @userName";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@userName", currentUser);

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        private void BtnApptType_Click(object sender, EventArgs e)
        {
            ApptByTypeForm typeForm = new ApptByTypeForm(this);
            typeForm.Show();
        }

        private void SetDgvToBuffer(DataGridView dgv)
        {
            dgv.DataSource = DgvBuffer.DataSource;
        }
        public void SetReportDgv()
        {
            SetDgvToBuffer(DgvReports);
        }

        public void SetTotalNumLbl(int found)
        {
                LbLTotalNum.Text = found.ToString();
        }

        private void BtnApptClient_Click(object sender, EventArgs e)
        {
            ApptByClientForm apptClientForm = new ApptByClientForm(this);
            apptClientForm.Show();
        }

        private void BtnConsultant_Click(object sender, EventArgs e)
        {
            ApptByConsultant apptConsultantForm = new ApptByConsultant(this);
            apptConsultantForm.Show();
        }

        public void SetTypeReportHeaders()
        {
            DgvReports.Columns["customerName"].HeaderText = "Client Name";
            DgvReports.Columns["type"].HeaderText = "Appt. Type";
            DgvReports.Columns["start"].HeaderText = "Start Time";
            DgvReports.Columns["end"].HeaderText = "End Time";
        }

        public void SetClientReportHeaders()
        {
            DgvReports.Columns["customerName"].HeaderText = "Client Name";
            DgvReports.Columns["type"].HeaderText = "Appt. Type";
            DgvReports.Columns["start"].HeaderText = "Start Time";
            DgvReports.Columns["end"].HeaderText = "End Time";
        }

        public void SetConsultantReportHeaders()
        {
            DgvReports.Columns["customerName"].HeaderText = "Client Name";
            DgvReports.Columns["userName"].HeaderText = "Consultant Name";
            DgvReports.Columns["start"].HeaderText = "Start Time";
            DgvReports.Columns["end"].HeaderText = "End Time";
            DgvReports.Columns["type"].HeaderText = "Appt. Type";
        }

        private void BtnApptDelete_Click(object sender, EventArgs e)
        {
            if (DgvCalendar.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure that you want to delete this appointment and all related data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = src.Database.DbConnection.conn;

                    string customerId = DgvCalendar.SelectedRows[0].Cells["customerId"].Value.ToString();

                    DateTime startTimeLocal = Convert.ToDateTime(DgvCalendar.SelectedRows[0].Cells["start"].Value);
                    DateTime endTimeLocal = Convert.ToDateTime(DgvCalendar.SelectedRows[0].Cells["end"].Value);

                    DateTime startTimeUTC = startTimeLocal.ToUniversalTime();
                    DateTime endTimeUTC = endTimeLocal.ToUniversalTime();

                    string getAppointmentIdQuery = "SELECT appointmentId FROM appointment WHERE customerId = @customerId AND start = @startTimeUTC AND end = @endTimeUTC";
                    MySqlCommand getAppIdCommand = new MySqlCommand(getAppointmentIdQuery, conn);
                    getAppIdCommand.Parameters.AddWithValue("@customerId", customerId);
                    getAppIdCommand.Parameters.AddWithValue("@startTimeUTC", startTimeUTC);
                    getAppIdCommand.Parameters.AddWithValue("@endTimeUTC", endTimeUTC);

                    object result = getAppIdCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Appointment not found!");
                        return;
                    }

                    string appointmentId = result.ToString();

                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {

                        string deleteAppointmentQuery = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                        MySqlCommand deleteAppointmentCommand = new MySqlCommand(deleteAppointmentQuery, conn);
                        deleteAppointmentCommand.Parameters.AddWithValue("@appointmentId", appointmentId);
                        deleteAppointmentCommand.Transaction = transaction;
                        deleteAppointmentCommand.ExecuteNonQuery();

                        transaction.Commit();

                        RefreshCalendarDgv(); 
                        MessageBox.Show("Appointment and all related data deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void BtnApptUpdate_Click(object sender, EventArgs e)
        {
            if (DgvCalendar.SelectedRows.Count <= 0 || DgvCalendar.SelectedRows.Count > 1)
            {
                MessageBox.Show("You must select a single row to update.");
                return;
            }
            else
            {
                DataGridViewRow row = DgvCalendar.SelectedRows[0];
                Appointment appointment = new Appointment(
                    row.Cells["customerId"].Value.ToString(),
                    row.Cells["customerName"].Value.ToString(),
                    row.Cells["type"].Value.ToString(),
                    (DateTime)row.Cells["start"].Value,
                    (DateTime)row.Cells["end"].Value
                ) ;

                UpdateApptForm updateForm = new UpdateApptForm(this, appointment);
                updateForm.Show();
            }
        }
    }
}

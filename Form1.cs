using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClientAppointmentManager.src.Database;
using System.Threading;
using System.Globalization;
using System.IO;

namespace ClientAppointmentManager
{
    public partial class Form1 : Form
    {
        public HubForm hubForm;

        public Form1()
        {
            InitializeComponent();
            CheckLanguage();
            TbPassword.UseSystemPasswordChar = true;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = TbUsername.Text;
            string password = TbPassword.Text;
            MySqlConnection conn = DbConnection.conn;
            
            string query = "SELECT COUNT(*) " +
                "FROM user WHERE userName = @username AND password = @password";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", password);

            int count = Convert.ToInt32(command.ExecuteScalar());

            if(count > 0)
            {
                hubForm = new HubForm(this, TbUsername.Text);
                this.Hide();
                LogAttempt(true);
                CheckUpcomingAppointments(TbUsername.Text);
                hubForm.Show();
            }
            else
            {
                if(CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
                {
                    MessageBox.Show("Nombre de usuario o contraseña no válidos");
                }
                else
                {
                    LogAttempt(false);
                    MessageBox.Show("Invalid username or password.");
                }
                
            }
        }

        private void CheckLanguage()
        {
            if(CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
            {
                LblTitle.Text = @"Sistema de Gestión de Clientes";
                LblUsername.Text = @"Nombre de usuario";
                LblPassword.Text = @"Contraseña";
                BtnLogin.Text = @"Iniciar sesión";
            }
        }

        public void CheckUpcomingAppointments(string userName)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

            // Query to fetch the userId using userName.
            string userIdQuery = "SELECT userId FROM user WHERE userName = @userName";
            MySqlCommand cmdUserId = new MySqlCommand(userIdQuery, conn);
            cmdUserId.Parameters.AddWithValue("@userName", userName);

            object userIdResult = cmdUserId.ExecuteScalar();

            if (userIdResult == null)
            {
                MessageBox.Show("Invalid User Name.");
                return; // Exit the function if no userId is found.
            }

            int userId = Convert.ToInt32(userIdResult);

            // Now we proceed to check for appointments.
            DateTime currentTime = DateTime.Now;
            DateTime windowEnd = currentTime.AddMinutes(15);

            string query = @"
                SELECT start 
                FROM appointment 
                WHERE userId = @userId 
                AND start > @currentTime 
                AND start <= @windowEnd";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@currentTime", currentTime);
            cmd.Parameters.AddWithValue("@windowEnd", windowEnd);

            // Execute the query.
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                DateTime appointmentTime = Convert.ToDateTime(result);
                MessageBox.Show($"You have an upcoming appointment at {appointmentTime.ToShortTimeString()}!");
            }
        }

        // Will store AccessAttemptLog.txt in the working directory (bin/debug for dev enviornment)
        void LogAttempt(bool isLoggedIn)
        {
            string path = "AccessAttemptLog.txt";

            // Using lambda to determine the log message based on the login status
            Func<bool, string> determineLogMessage = isSuccess => isSuccess ?
                $"{TbUsername.Text} has logged in at {DateTime.UtcNow} UTC" :
                $"Failed login attempt with {TbUsername.Text} at {DateTime.UtcNow} UTC"; // Makes code easier to read and easy to change if needed.

            string logMessage = determineLogMessage(isLoggedIn);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(logMessage);
            }
        }

    }
}

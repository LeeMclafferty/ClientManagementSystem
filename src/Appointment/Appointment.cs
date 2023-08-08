using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClientAppointmentManager.src.Appointment
{
    public class Appointment
    {
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string type { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime dateEnd { get; set; }
        public DateTime timeEnd { get; set; }
        public Appointment()
        {

        }
        public void Schedule(string userId, string userName)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;
            conn.Open();  // Ensure the connection is open.

            // Constructing the datetime values for the start and end of the appointment
            DateTime startDateTimeLocal = dateStart.Add(timeStart.TimeOfDay);
            DateTime endDateTimeLocal = dateEnd.Add(timeEnd.TimeOfDay);

            // Convert the local datetime values to UTC
            DateTime startDateTimeUTC = startDateTimeLocal.ToUniversalTime();
            DateTime endDateTimeUTC = endDateTimeLocal.ToUniversalTime();

            string query = @"
        INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, 
            createDate, createdBy, lastUpdate, lastUpdateBy) 
        VALUES (@customerId, @userId, @title, @description, @location, @contact, @type, @url ,@start, @end, 
            NOW(), @createdBy, NOW(), @lastUpdateBy)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@title", "not needed");
            cmd.Parameters.AddWithValue("@description", "not needed");
            cmd.Parameters.AddWithValue("@location", "not needed");
            cmd.Parameters.AddWithValue("@contact", "not needed");
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@url", "not needed");
            cmd.Parameters.AddWithValue("@start", startDateTimeUTC);
            cmd.Parameters.AddWithValue("@end", endDateTimeUTC);
            cmd.Parameters.AddWithValue("@createdBy", userName);
            cmd.Parameters.AddWithValue("@lastUpdateBy", userName);

            cmd.ExecuteNonQuery();
        }
    }
}

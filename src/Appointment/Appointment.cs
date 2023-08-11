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
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }

        public Appointment()
        {

        }

        public Appointment(string id, string name, string typeIn, DateTime start, DateTime end)
        {
            customerId = id;
            customerName = name;
            type = typeIn;
            timeStart = start;
            timeEnd = end;

        }

        public void Schedule(string userId, string userName)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;

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
            cmd.Parameters.AddWithValue("@start", timeStart);
            cmd.Parameters.AddWithValue("@end", timeEnd);
            cmd.Parameters.AddWithValue("@createdBy", userName);
            cmd.Parameters.AddWithValue("@lastUpdateBy", userName);

            cmd.ExecuteNonQuery();
        }

        public void Update(string userName, Appointment updatedAppointment)
        {
            MySqlConnection conn = src.Database.DbConnection.conn;
            // need to use the orginal values when the form is opened in the wehere clause.
            string query = @"
            UPDATE appointment 
            SET 
            customerId = @updatedCustomerId,
            type = @updatedType,
            start = @updatedStart,
            end = @updatedEnd,
            lastUpdate = NOW(),
            lastUpdateBy = @lastUpdateBy
            WHERE 
            customerId = @customerId 
            AND start = @start 
            AND end = @end 
            AND type = @type";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@updatedCustomerId", updatedAppointment.customerId);
            cmd.Parameters.AddWithValue("@updatedType", updatedAppointment.type);
            cmd.Parameters.AddWithValue("@updatedStart", updatedAppointment.timeStart.ToUniversalTime());
            cmd.Parameters.AddWithValue("@updatedEnd", updatedAppointment.timeEnd.ToUniversalTime());

            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@start", timeStart.ToUniversalTime());
            cmd.Parameters.AddWithValue("@end", timeEnd.ToUniversalTime());
            cmd.Parameters.AddWithValue("@lastUpdateBy", userName);


            cmd.ExecuteNonQuery();
        }

    }
}

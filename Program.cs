﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAppointmentManager.src.Database;

namespace ClientAppointmentManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DbConnection.StartConnection();
            Application.Run(new Form1());
            DbConnection.CloseConnection();
        }
    }
}

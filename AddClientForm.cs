using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAppointmentManager.src.Client;

namespace ClientAppointmentManager
{
    public partial class AddClientForm : Form
    {
        HubForm parentForm;
        public AddClientForm(HubForm form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!CanAddNewClient())
            {
                return;
            }
            Client client = new Client(
                TbClientName.Text,
                TbAddress1.Text,
                TbAddress2.Text,
                TbPostal.Text,
                TbPhone.Text,
                TbCity.Text,
                TbCountry.Text
                );

            parentForm.AddCustomer(client);
            Close();
        }

        private bool CanAddNewClient()
        {
            int check;
            if(TbClientName.Text.Trim() == "")
            {
                TbClientName.BackColor = Color.Red;
                return false;
            }
            else if (TbAddress1.Text.Trim() == "")
            {
                TbAddress1.BackColor = Color.Red;
                return false;
            }
            else if (!int.TryParse(TbPostal.Text, out check))
            {
                MessageBox.Show("Your postal code has to be a number.", "Error");
                return false;
            }
            else if (TbPostal.Text.Length != 5)
            {
                MessageBox.Show("Enter a 5 digit postal code.", "Error");
                return false;
            }
            else if (TbPhone.Text.Trim() == "")
            {
                TbPhone.BackColor = Color.Red;
                return false;
            }
            else if(!IsValidPhoneNumber(TbPhone.Text))
            {
                MessageBox.Show("Phone number format must be: ###-####", "Error");
                return false;
            }
            else if (TbCity.Text.Trim() == "")
            {
                TbCity.BackColor = Color.Red;
                return false;
            }
            else if (TbCountry.Text.Trim() == "")
            {
                TbCountry.BackColor = Color.Red;
                return false;
            }

            return true;
        }

        public bool IsValidPhoneNumber(string phoneString)
        {
            Regex phoneRegex = new Regex(@"^\d{3}-\d{4}$");
            return phoneRegex.IsMatch(phoneString);
        }
    }
}

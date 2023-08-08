using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAppointmentManager.src.Client;

namespace ClientAppointmentManager
{
    public partial class UpdateClient : Form
    {
        HubForm parentForm;
        Client client;
        public UpdateClient(HubForm form, Client customer)
        {
            InitializeComponent();
            parentForm = form;
            client = customer;
            FillClientInfo();
        }

        private void FillClientInfo()
        {
            TbClientName.Text = client.name;
            TbPhone.Text = client.phoneNum;
            TbAddress1.Text = client.fullAddress.address;
            TbAddress2.Text = client.fullAddress.address2;
            TbPostal.Text = client.fullAddress.postalCode;
            TbCity.Text = client.cityName;
            TbCountry.Text = client.countryName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Client changedCustomer = new Client(
                TbClientName.Text,
                TbAddress1.Text,
                TbAddress2.Text,
                TbPostal.Text,
                TbPhone.Text,
                TbCity.Text,
                TbCountry.Text
                );
            changedCustomer.ids = client.ids;
            parentForm.UpdateCustomer(changedCustomer);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

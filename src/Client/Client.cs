using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentManager.src.Client
{
    public class Client
    {
        public string name { get; set; }
        
        public Address fullAddress = new Address();
        public ClientIds ids = new ClientIds();

        public string phoneNum { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }

        public Client(string clientName, string add1, string add2, string zipCode, string phone, string city, string country)
        {
            name = clientName;
            fullAddress.address = add1;
            fullAddress.address2 = add2;
            fullAddress.postalCode = zipCode;
            phoneNum = phone;
            cityName = city;
            countryName = country;
        }
        /* Constructor that takes in Ids*/
        public Client(string clientName, string add1, string add2, string zipCode, string phone, string city, string country,
            string custId, string addressId, string cityId, string countryId)
        {
            name = clientName;
            fullAddress.address = add1;
            fullAddress.address2 = add2;
            fullAddress.postalCode = zipCode;
            phoneNum = phone;
            cityName = city;
            countryName = country;

            ids = new ClientIds(
                custId,
                addressId,
                cityId,
                countryId
                );
        }

        public Address GetAddress()
        {
            return fullAddress;
        }

    }
}

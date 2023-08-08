using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentManager.src.Client
{
    public class ClientIds
    {
        public string customerId { get; set; }
        public string addressId { get; set; }
        public string cityId { get; set; }
        public string countryId { get; set; }

        public ClientIds()
        {

        }
        public ClientIds(string custId, string addId, string citId, string counId)
        {
            customerId = custId;
            addressId = addId;
            cityId = citId;
            countryId = counId;
        }
    }
}

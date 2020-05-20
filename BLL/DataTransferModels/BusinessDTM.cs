using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.BLL.DataTransferModels
{
    public class BusinessDTM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public int Time_zoneId { get; set; }
        public byte[] Logo { get; set; }
        public string Webpage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string RegistrationNumber { get; set; }

    }
}
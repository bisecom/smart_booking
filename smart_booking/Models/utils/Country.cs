using smart_booking.Models.business;
using smart_booking.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.Models.utils
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonePrefix { get; set; }
        public byte[] FlagImage { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Time_zone> Time_zones { get; set; }
        public Country()
        {
            Businesses = new List<Business>();
            Users = new List<User>();
            Time_zones = new List<Time_zone>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> CategoryServices { get; set; }
        public ServiceCategory()
        {
            CategoryServices = new List<Service>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class MUserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public MUserRole()
        {
            Users = new List<User>();
        }
    }
}
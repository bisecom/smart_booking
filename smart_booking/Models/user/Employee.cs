using smart_booking.Models.business;
using smart_booking.Models.calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.Models.user
{
    public class Employee
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsOwner { get; set; }
        
        public virtual CalendarSetting CalendarSetting { get; set; }
        public virtual CustomerNotification CustomerNotification { get; set; }
        public virtual TeamNotification TeamNotification { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual WorkingHour WorkingHour { get; set; }
        public virtual Slot Slot { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }

        public Employee()
        {
            Slots = new List<Slot>();
        }

    }
}
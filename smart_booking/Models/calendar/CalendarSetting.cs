using smart_booking.Models.user;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.Models.calendar
{
    public class CalendarSetting
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int View { get; set; }
        public DateTime FirstHour { get; set; }
        public int WorkingDayDuration { get; set; }
        public int SlotDuration { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
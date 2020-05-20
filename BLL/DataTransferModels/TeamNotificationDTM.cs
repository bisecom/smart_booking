using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class TeamNotificationDTM
    {
        public int EmployeeId { get; set; }
        public bool AfterBooked { get; set; }
        public bool AfterRescheduled { get; set; }
        public bool Collegue { get; set; }
        public bool CollegueAndOwner { get; set; }
        public bool Owner { get; set; }
    }
}
using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CustomerNotificationDTM
    {
        public int EmployeeId { get; set; }
        public bool AfterBooked { get; set; }
        public bool AfterRescheduled { get; set; }
        public bool AfterCancelled { get; set; }
    }
}
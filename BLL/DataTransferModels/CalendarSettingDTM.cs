using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CalendarSettingDTM
    {
        public int EmployeeId { get; set; }
        public int View { get; set; }
        public DateTime? FirstHour { get; set; }
        public int WorkingDayDuration { get; set; }
        public int SlotDuration { get; set; }
    }
}
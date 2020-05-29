using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class PermissionDTM
    {
        public int EmployeeId { get; set; }
        public bool IsSummary { get; set; }
        public bool IsOthersCalendar { get; set; }
        public bool IsClients { get; set; }
        public bool IsServices { get; set; }
        public bool IsReports { get; set; }
        public virtual EmployeeDTM Employee { get; set; }
    }
}
using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class SlotDTM
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public virtual EmployeeDTM Employee { get; set; }
        public int CountryId { get; set; }
        public DateTime? SlotDateTime { get; set; }
        public int Duration { get; set; }
        public bool IsPadding { get; set; }
        public int PaddingAfter { get; set; }
        public int Reiteration { get; set; }
        public float Price { get; set; }
        public int ResponsibleId { get; set; }
        public virtual EmployeeDTM Responsible { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public bool IsTimeBlock { get; set; }
        public bool IsReminderNeeded { get; set; }
        public int ReminderInterval { get; set; }
        public virtual CountryDTM Country { get; set; }
        public virtual ServiceDTM Service { get; set; }
    }
}
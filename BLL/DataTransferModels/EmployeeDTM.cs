using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class EmployeeDTM
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public virtual BusinessDTM Business { get; set; }
        public string UserId { get; set; }
        public virtual UserDTM User { get; set; }
        public bool IsOwner { get; set; }

        public virtual CalendarSettingDTM CalendarSetting { get; set; }
        public virtual CustomerNotificationDTM CustomerNotification { get; set; }
        public virtual TeamNotificationDTM TeamNotification { get; set; }
        public virtual PermissionDTM Permission { get; set; }
        public virtual WorkingHourDTM WorkingHour { get; set; }
        public virtual SlotDTM Slot { get; set; }
        public virtual ICollection<SlotDTM> Slots { get; set; }
        public EmployeeDTM()
        {
            Slots = new List<SlotDTM>();
        }
    }
}
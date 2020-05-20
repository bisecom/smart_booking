using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class EmployeeDTM
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public int? UserId { get; set; }
        public bool IsOwner { get; set; }
    }
}
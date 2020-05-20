﻿using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class UserDTM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
      
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public int? CountryId { get; set; }
        public int? Time_ZoneId { get; set; }
        public byte[] UserPicture { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int PlanId { get; set; }
        public byte? PaymentOverdue { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? UserRoleId { get; set; }
    }
}
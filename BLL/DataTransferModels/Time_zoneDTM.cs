using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class Time_zoneDTM
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public string CountryCode { get; set; }
        public string UTC_Jan_1_2020 { get; set; }
        public string DST_Jul_1_2020 { get; set; }
    }
}
using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CountryDTM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonePrefix { get; set; }
        public byte[] FlagImage { get; set; }
        
    }
}
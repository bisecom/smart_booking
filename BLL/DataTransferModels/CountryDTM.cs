using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CountryDTM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        public string PhonePrefix { get; set; }
        public string Capital { get; set; }
        public string Currency_ { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }

    }
}
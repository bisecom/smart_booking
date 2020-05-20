using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class ServiceDTM
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public int PaddingAfter { get; set; }
        public byte[] Picture { get; set; }
    }
}
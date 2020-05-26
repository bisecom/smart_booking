using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class ServiceCategoryDTM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ServiceDTM> CategoryServices { get; set; }
        public ServiceCategoryDTM()
        {
            CategoryServices = new List<ServiceDTM>();
        }
    }
}
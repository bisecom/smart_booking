using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ServiceDTMServiceRepo : IServiceRepository<ServiceDTM>
    {
        IUnitOfWork Database { get; set; }

        public ServiceDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ServiceDTM>> GetAll(SearchParams search)
        {
            IQueryable<Service> servicesQuery = Database.Services.GetAll();
            List<Service> temp = servicesQuery
            .Where(t => t.BusinessId == search.BusinessId)
            .ToList();
            List<ServiceDTM> tempList = new List<ServiceDTM>();

            if (temp != null)
            foreach (var s in temp)
            {
                    tempList.Add(SeviceToServiceDtmMap(s));
            }

            return tempList;
        }

        public async Task<ServiceDTM> Get(int id)
        {
            int firstServiceId = 1;
            if (id < firstServiceId)
                throw new ValidationException("Service id is not specified correctly", "");
            var service = await Database.Services.Get(id);
            if (service == null)
                throw new ValidationException("Service is not found", "");

            ServiceDTM serviceDtm = SeviceToServiceDtmMap(service);
            return serviceDtm;
        }

        public IQueryable<ServiceDTM> Find(Func<ServiceDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ServiceDTM serviceDtm)
        {
            try
            {
                Service service = new Service();
                service.Name = serviceDtm.Name;
                service.Description = serviceDtm.Description;
                service.Price = serviceDtm.Price;
                service.Duration = serviceDtm.Duration;
                service.PaddingAfter = serviceDtm.PaddingAfter;
                service.Picture = serviceDtm.Picture;

                service.Business = await Database.BllServices.GetBusiness(serviceDtm.Business.Id);
                service.ServiceCategory = await Database.BllServices.ServiceCategory(serviceDtm.ServiceCategory.Id);

                await Database.Services.Create(service);
                return service.Id;
            }
            catch { return 0; }


        }

        public async Task<bool> Update(ServiceDTM serviceDtm)
        {
            try
            {
                Service service = new Service();
                service.Name = serviceDtm.Name;
                service.Description = serviceDtm.Description;
                service.Price = serviceDtm.Price;
                service.Duration = serviceDtm.Duration;
                service.PaddingAfter = serviceDtm.PaddingAfter;
                service.Picture = serviceDtm.Picture;

                service.Business = await Database.BllServices.GetBusiness(serviceDtm.Business.Id);
                service.ServiceCategory = await Database.BllServices.ServiceCategory(serviceDtm.ServiceCategory.Id);

                return await Database.Services.Update(service) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Database.Services.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public ServiceDTM SeviceToServiceDtmMap(Service service)
        {
            ServiceDTM serviceDtm = new ServiceDTM();
            serviceDtm.Id = service.Id;
            serviceDtm.Name = service.Name;
            serviceDtm.Description = service.Description;
            serviceDtm.Price = service.Price;
            serviceDtm.Duration = service.Duration;
            serviceDtm.PaddingAfter = service.PaddingAfter;
            serviceDtm.Picture = service.Picture;

            serviceDtm.BusinessId = service.BusinessId;
            serviceDtm.ServiceCategoryId = service.ServiceCategoryId;

            return serviceDtm;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

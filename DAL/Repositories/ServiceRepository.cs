using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ServiceRepository : IRepository<Service>
    {
        private SBContext db;

        public ServiceRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Service item)
        {
            try
            {
                db.Services.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Service service = await db.Services.FindAsync(id);
                if (service != null)
                {
                    db.Services.Remove(service);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Service> Find(Func<Service, bool> predicate)
        {
            return db.Services.AsQueryable();
        }

        public async Task<Service> Get(int id)
        {
            return await db.Services
                .Include("Business")
                .Include("ServiceCategory")
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Service> GetAll()
        {
            return db.Services.AsQueryable();
        }

        public async Task<bool> Update(Service service)
        {
            try
            {
                var initialService = await db.Services.FindAsync(service.Id);
                if (initialService != null)
                {
                    initialService.Name = service.Name;
                    initialService.Description = service.Description;
                    initialService.Price = service.Price;
                    initialService.Duration = service.Duration;
                    initialService.PaddingAfter = service.PaddingAfter;
                    initialService.Picture = service.Picture;

                    if (initialService.Business.Id != service.Business.Id)
                    {
                        var business = db.Businesses.Include("Services").Single(s => s.Id == initialService.Business.Id);
                        var businessToDelete = business.Services.FirstOrDefault(ol => ol.Id == initialService.Id);
                        if (businessToDelete != null)
                            business.Services.Remove(businessToDelete);
                        initialService.Business = service.Business;
                    }

                    if (initialService.ServiceCategory.Id != service.ServiceCategory.Id)
                    {
                        var serviceCategory = db.ServiceCategories.Include("CategoryServices").Single(s => s.Id == initialService.ServiceCategory.Id);
                        var serviceToDelete = serviceCategory.CategoryServices.FirstOrDefault(ol => ol.Id == initialService.Id);
                        if (serviceToDelete != null)
                            serviceCategory.CategoryServices.Remove(serviceToDelete);
                        initialService.ServiceCategory = service.ServiceCategory;
                    }

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}

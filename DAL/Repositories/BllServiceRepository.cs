using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BllServiceRepository : IBllServicesUtils
    {
        private SBContext db;

        public BllServiceRepository(SBContext context)
        {
            this.db = context;
        }
        public async Task<Booking> GetBooking(int id)
        {
            return db.Bookings.Find(id);
        }

        public async Task<Business> GetBusiness(int id)
        {
            return db.Businesses.Find(id);
        }

        public async Task<CalendarSetting> GetCalendarSetting(int id)
        {
            return db.CalendarSettings.Find(id);
        }

        public async Task<Client> GetClient(int id)
        {
            return db.Clients.Find(id);
        }

        public async Task<Country> GetCountry(int id)
        {
            return db.Countries.Find(id);
        }

        public async Task<Currency> GetCurrency(int id)
        {
            return db.Currencies.Find(id);
        }

        public async Task<CustomerNotification> GetCustomerNotification(int id)
        {
            return db.CustomerNotifications.Find(id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                return db.Employees.Find(id);
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return null; }
        }

        public async Task<PageLanguage> GetPageLanguage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Permission> GetPermission(int id)
        {
            return db.Permissions.Find(id);
        }

        public async Task<Service> GetService(int id)
        {
            return db.Services.Find(id);
        }

        public async Task<Slot> GetSlot(int id)
        {
            return db.Slots.Find(id);
        }

        public async Task<TeamNotification> GetTeamNotification(int id)
        {
            return db.TeamNotifications.Find(id);
        }

        public async Task<Time_zone> GetTime_zone(int id)
        {
            return db.Time_zones.Find(id);
        }

        public async Task<User> GetUser(string id)
        {
            return db.Users.Find(id);
        }

        public async Task<WorkingBreak> GetWorkingBreak(int id)
        {
            return db.WorkingBreaks.Find(id);
        }

        public async Task<WorkingHour> GetWorkingHour(int id)
        {
            return db.WorkingHours.Find(id);
        }

        public async Task<ServiceCategory> ServiceCategory(int id)
        {
            return db.ServiceCategories.Find(id);
        }
    }
}

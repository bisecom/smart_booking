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
    public class EmployeeRepository : IRepository<Employee>
    {
        private SBContext db;

        public EmployeeRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Employee item)
        {
            try
            {
                db.Employees.Add(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Employee empl = await db.Employees.FindAsync(id);
                if (empl != null)
                    db.Employees.Remove(empl);
                    db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public IQueryable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees.AsQueryable();
        }

        public async Task<Employee> Get(int id)
        {
            //return await db.Employees.FindAsync(id);
            return await db.Employees
                .Include("User")
                .Include("Business")
                .Include("CalendarSetting")
                .Include("CustomerNotification")
                .Include("TeamNotification")
                .Include("Permission")
                .Include("WorkingHour")
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Employee> GetAll()
        {
            return db.Employees.Include("User").AsQueryable();
        }

        public async Task<bool> Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
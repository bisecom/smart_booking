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

        public bool Create(Employee item)
        {
            try
            {
                db.Employees.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Employee empl = db.Employees.Find(id);
                if (empl != null)
                    db.Employees.Remove(empl);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees;
        }

        public async Task<Employee> Get(int id)
        {
            return await db.Employees.FindAsync(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Employee item)
        {
            try
            {
                var initialEmpl = await Get(item.Id);
                db.Entry(initialEmpl).CurrentValues.SetValues(item);
                return true;
            }
            catch { return false; }
        }
    }
}
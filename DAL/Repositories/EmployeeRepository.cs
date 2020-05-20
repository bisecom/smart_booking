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

        public void Create(Employee item)
        {
            db.Employees.Add(item);
        }

        public void Delete(string id)
        {
            Employee empl = db.Employees.Find(id);
            if (empl != null)
                db.Employees.Remove(empl);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees;
        }

        public Employee Get(string id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
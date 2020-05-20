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
    public class DalUnitOfWork : IUnitOfWork
    {
        private SBContext db;
        private UserRepository userRepository;
        private EmployeeRepository employeeRepository;
        private CountryRepository countryRepository;
        private UserRoleRepository userRoleRepository;
        private Time_ZoneRepository time_zoneRepository;

        public DalUnitOfWork()
        { 
            db = new SBContext("SBContext");
        }

        public IUserRepository Users  {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<UserRole> UserRoles {
            get
            {
                if (userRoleRepository == null)
                    userRoleRepository = new UserRoleRepository(db);
                return userRoleRepository;
            }
        }

        public IRepository<Employee> Employees {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Country> Countries {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }

        public IRepository<Time_zone> Time_zones {
            get
            {
                if (time_zoneRepository == null)
                    time_zoneRepository = new Time_ZoneRepository(db);
                return time_zoneRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

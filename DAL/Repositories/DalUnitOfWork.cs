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
        private BusinessRepository businessRepository;
        private EmployeeRepository employeeRepository;
        private CountryRepository countryRepository;
        //private UserRoleRepository userRoleRepository;
        private Time_ZoneRepository time_zoneRepository;
        private BookingRepository bookingRepository;
        private CurrencyRepository currencyRepository;

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

        //public IRepository<MUserRole> MUserRoles {
        //    get
        //    {
        //        if (userRoleRepository == null)
        //            userRoleRepository = new UserRoleRepository(db);
        //        return userRoleRepository;
        //    }
        //}

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }
         
        public IRepository<Currency> Currencies
        {
            get
            {
                if (currencyRepository == null)
                    currencyRepository = new CurrencyRepository(db);
                return currencyRepository;
            }
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }

        public IRepository<Business> Businesses
        {
            get
            {
                if (businessRepository == null)
                    businessRepository = new BusinessRepository(db);
                return businessRepository;
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

        public async void Save()
        {
            await db.SaveChangesAsync();
        }
    }
}

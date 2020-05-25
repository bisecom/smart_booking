using BLL.Interfaces;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BllUnitOfWork : IUnitOfWorkService
    {
        IUnitOfWork Database { get; set; }
        private UserDTMServiceRepo UsersDtmRepo;
        private BusinessDTMServiceRepo BusinessesDtmRepo;
        private CountryDTMServiceRepo CountriesDtmRepo;
        private Time_ZoneDTMServiceRepo Time_ZoneDtmRepo;
        private BookingDTMServiceRepo BookingDtmRepo;
        public BllUnitOfWork(IUnitOfWork db)
        {
            Database = db;
        }

        public IUserServiceRepository UsersDTM
        {
            get
            {
                if (UsersDtmRepo == null)
                    UsersDtmRepo = new UserDTMServiceRepo(Database);
                return UsersDtmRepo;
            }
        }

        public IServiceRepository<BookingDTM> BookingsDTM
        {
            get
            {
                if (BookingDtmRepo == null)
                    BookingDtmRepo = new BookingDTMServiceRepo(Database);
                return BookingDtmRepo;
            }
        }
        public IServiceRepository<BusinessDTM> BusinessesDTM
        {
            get
            {
                if (BusinessesDtmRepo == null)
                    BusinessesDtmRepo = new BusinessDTMServiceRepo(Database);
                return BusinessesDtmRepo;
            }
        }

        public IServiceRepository<CountryDTM> CountriesDTM
        {
            get
            {
                if (CountriesDtmRepo == null)
                    CountriesDtmRepo = new CountryDTMServiceRepo(Database);
                return CountriesDtmRepo;
            }
        }
        
        public IServiceRepository<Time_zoneDTM> TimezonesDTM
        {
            get
            {
                if (Time_ZoneDtmRepo == null)
                    Time_ZoneDtmRepo = new Time_ZoneDTMServiceRepo(Database);
                return Time_ZoneDtmRepo;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public bool SaveChanges()
        //{
        //    try
        //    {
        //        Database.Save();
        //        return true;
        //    }
        //    catch { return false; }
        //}
    }
}

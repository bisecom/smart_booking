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
        public BllUnitOfWork(IUnitOfWork db)
        {
            Database = db;
        }

        public IServiceRepository<UserDTM> UsersDTM
        {
            get
            {
                if (UsersDtmRepo == null)
                    UsersDtmRepo = new UserDTMServiceRepo(Database);
                return UsersDtmRepo;
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

        public void SaveChanges()
        {
            Database.Save();
        }
    }
}

using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {
        IServiceRepository<UserDTM> UsersDTM { get; }
        void SaveChanges();
    }
}

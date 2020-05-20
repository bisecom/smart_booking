using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserServiceRepository
    {
        IQueryable<UserDTM> GetAll();
        UserDTM Get(string id);
        IQueryable<UserDTM> Find(Func<UserDTM, Boolean> predicate);
        bool Create(UserDTM item);
        bool Update(UserDTM item);
        bool Delete(string id);
    }
}

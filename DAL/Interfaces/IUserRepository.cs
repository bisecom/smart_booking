using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> Get(string id);
        IQueryable<User> Find(Func<User, Boolean> predicate);
        bool Create(User item);
        bool Update(User item);
        bool Delete(string id);
    }
}

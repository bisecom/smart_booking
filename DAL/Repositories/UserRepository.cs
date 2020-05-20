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
    public class UserRepository : IUserRepository
    {
        private SBContext db;

        public UserRepository(SBContext context)
        {
            this.db = context;
        }
        public bool Create(User item)
        {
            try
            {
                db.Users.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(string id)
        {
            try
            {
                User user = db.Users.Find(id);
                if (user != null)
                    db.Users.Remove(user);
                return true;
            }
            catch { return false; }
            
        }

        public IQueryable<User> Find(Func<User, bool> predicate)//should be deleted
        {
            return db.Users;
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public IQueryable<User> GetAll()
        {
            return db.Users.AsQueryable();
        }
        
        public bool Update(User user)
        {
            try
            {
                var initialUser = Get(user.Id);
                db.Entry(initialUser).CurrentValues.SetValues(user);
                return true;
            }
            catch { return false; }
        }
    }
}

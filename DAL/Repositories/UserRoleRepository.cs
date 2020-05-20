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
    public class UserRoleRepository : IRepository<UserRole>
    {
        private SBContext db;

        public UserRoleRepository(SBContext context)
        {
            this.db = context;
        }

        public bool Create(UserRole item)
        {
            try
            {
                db.UserRoles.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                UserRole userRole = db.UserRoles.Find(id);
                if (userRole != null)
                    db.UserRoles.Remove(userRole);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<UserRole> Find(Func<UserRole, bool> predicate)
        {
            return db.UserRoles;
        }

        public UserRole Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetAll()
        {
            return db.UserRoles;
        }

        public bool Update(UserRole item)
        {
            try
            {
                db.Entry(item).State = EntityState.Modified;
                return true;
            }
            catch { return false; }
        }
    }
}

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

        public void Create(UserRole item)
        {
            db.UserRoles.Add(item);
        }

        public void Delete(string id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole != null)
                db.UserRoles.Remove(userRole);
        }

        public IEnumerable<UserRole> Find(Func<UserRole, bool> predicate)
        {
            return db.UserRoles;
        }

        public UserRole Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetAll()
        {
            return db.UserRoles;
        }

        public void Update(UserRole item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

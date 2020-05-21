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
    public class UserRoleRepository : IRepository<MUserRole>
    {
        private SBContext db;

        public UserRoleRepository(SBContext context)
        {
            this.db = context;
        }

        public bool Create(MUserRole item)
        {
            try
            {
                db.MUserRoles.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                MUserRole userRole = db.MUserRoles.Find(id);
                if (userRole != null)
                    db.MUserRoles.Remove(userRole);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<MUserRole> Find(Func<MUserRole, bool> predicate)
        {
            return db.MUserRoles;
        }

        public MUserRole Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MUserRole> GetAll()
        {
            return db.MUserRoles;
        }

        public bool Update(MUserRole item)
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

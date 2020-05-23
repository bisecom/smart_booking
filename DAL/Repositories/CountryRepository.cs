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
    public class CountryRepository : IRepository<Country>
    {
        private SBContext db;

        public CountryRepository(SBContext context)
        {
            this.db = context;
        }

        public bool Create(Country item)
        {
            try
            {
                db.Countries.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Country country = db.Countries.Find(id);
                if (country != null)
                    db.Countries.Remove(country);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return db.Countries;
        }

        public async Task<Country> Get(int id)
        {
            return await db.Countries.FindAsync(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public bool Update(Country item)
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

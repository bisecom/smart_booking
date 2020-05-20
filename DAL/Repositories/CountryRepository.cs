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

        public void Create(Country item)
        {
            db.Countries.Add(item);
        }

        public void Delete(string id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
                db.Countries.Remove(country);
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return db.Countries;
        }

        public Country Get(string id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public void Update(Country item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

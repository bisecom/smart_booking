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
    public class Time_ZoneRepository : IRepository<Time_zone>
    {
        private SBContext db;

        public Time_ZoneRepository(SBContext context)
        {
            this.db = context;
        }

        public bool Create(Time_zone item)
        {
            try
            {
                db.Time_zones.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Time_zone tz = db.Time_zones.Find(id);
                if (tz != null)
                    db.Time_zones.Remove(tz);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Time_zone> Find(Func<Time_zone, bool> predicate)
        {
            return db.Time_zones;
        }

        public async Task<Time_zone> Get(int id)
        {
            return await db.Time_zones.FindAsync(id);
        }

        public IEnumerable<Time_zone> GetAll()
        {
            return db.Time_zones;
        }

        public async Task<bool> Update(Time_zone item)
        {
            try
            {
                var initialTz = await Get(item.Id);
                db.Entry(initialTz).CurrentValues.SetValues(item);
                return true;
            }
            catch { return false; }
        }
    }
}

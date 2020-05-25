using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private SBContext db;

        public BookingRepository(SBContext context)
        {
            this.db = context;
        }

        public Task<bool> Create(Booking item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Booking> Find(Func<Booking, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Booking item)
        {
            throw new NotImplementedException();
        }
    }
}

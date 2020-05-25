using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingDTMServiceRepo : IServiceRepository<BookingDTM>
    {
        IUnitOfWork Database { get; set; }

        public BookingDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<BookingDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDTM> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BookingDTM> Find(Func<BookingDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int>Create(BookingDTM item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BookingDTM item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

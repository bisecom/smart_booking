using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CurrencyDTMServiceRepo : IServiceRepository<CurrencyDTM>
    {
        IUnitOfWork Database { get; set; }

        public CurrencyDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<CurrencyDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDTM> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CurrencyDTM> Find(Func<CurrencyDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(CurrencyDTM item)
        {
            try
            {
                Currency currency = new Currency { Name = item.Name };
                await Database.Currencies.Create(currency);
                return currency.Id;
            }
            catch { return 0; }
        }

        public Task<bool> Update(CurrencyDTM item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using BLL.Interfaces;
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
    class CountryDTMServiceRepo : IServiceRepository<CountryDTM>
    {
        IUnitOfWork Database { get; set; }

        public CountryDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool Create(CountryDTM item)
        {
            try
            {
                Country country = new Country
                {
                    Code = item.Code,
                    Name = item.Name,
                    Native = item.Native,
                    PhonePrefix = item.PhonePrefix,
                    Capital = item.Capital,
                    Currency_ = item.Currency_,
                    Emoji  = item.Emoji,
                    EmojiU = item.EmojiU
                    };

                Database.Countries.Create(country);
                Database.Save();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTM> Find(Func<CountryDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public CountryDTM Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTM> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(CountryDTM item)
        {
            throw new NotImplementedException();
        }
    }
}

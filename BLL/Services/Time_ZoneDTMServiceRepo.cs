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
    public class Time_ZoneDTMServiceRepo : IServiceRepository<Time_zoneDTM>
    {
        IUnitOfWork Database { get; set; }

        public Time_ZoneDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }
        public bool Create(Time_zoneDTM item)
        {
            try
            {
                Time_zone zone = new Time_zone
                {
                    Zone = item.Zone,
                    CountryCode = item.CountryCode,
                    UTC_Jan_1_2020 = item.UTC_Jan_1_2020,
                    DST_Jul_1_2020 = item.DST_Jul_1_2020
                };

                Database.Time_zones.Create(zone);
                Database.Save();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Time_zoneDTM> Find(Func<Time_zoneDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Time_zoneDTM Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Time_zoneDTM> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Time_zoneDTM item)
        {
            throw new NotImplementedException();
        }
    }
}

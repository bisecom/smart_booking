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
    public class UserDTMServiceRepo : IServiceRepository<UserDTM>
    {
        IUnitOfWork Database { get; set; }

        public UserDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IQueryable<UserDTM> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTM userDtm)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<UserDTM> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTM Get(string id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");
            var user = Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("User не найден", "");

            return new UserDTM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                CountryId = user.CountryId,
                Time_ZoneId = user.Time_ZoneId,
                Birthdate = user.Birthdate,
                PlanId = user.PlanId,
                UserRoleId = user.UserRoleId,
                City = user.City
            };
        }

        public IEnumerable<UserDTM> Find(Func<UserDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Create(UserDTM userDtm)
        {
            try
            {
                User user = new User
                {
                    Id = userDtm.Id,
                    FirstName = userDtm.FirstName,
                    SecondName = userDtm.SecondName,
                    CountryId = userDtm.CountryId,
                    Time_ZoneId = userDtm.Time_ZoneId,
                    Birthdate = DateTime.Now,
                    PlanId = userDtm.PlanId,
                    UserRoleId = userDtm.UserRoleId,
                    City = userDtm.City

                };
                Database.Users.Create(user);
                Database.Save();
                return true;
            }
            catch { return false; }
        }
    }
}

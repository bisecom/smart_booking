using AutoMapper;
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
    public class UserDTMServiceRepo : IUserServiceRepository
    {
        IUnitOfWork Database { get; set; }

        public UserDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }
       
        public bool Update(UserDTM userDtm)
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
                    Birthdate = userDtm.Birthdate,
                    PlanId = userDtm.PlanId,
                    MUserRoleId = userDtm.UserRoleId,
                    City = userDtm.City
                };
                if (Database.Users.Update(user))
                {
                    Database.Save();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public bool Delete(string id)
        {
            try
            {
                Database.Users.Delete(id);
                Database.Save();
                return true;
            }
            catch { return false; }
        }

        public IQueryable<UserDTM> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTM>());
            var mapper = new Mapper(config);
            return mapper.Map<IQueryable<User>, IQueryable<UserDTM>>(Database.Users.GetAll());
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
                UserRoleId = user.MUserRoleId,
                City = user.City
            };
        }

        public IQueryable<UserDTM> Find(Func<UserDTM, bool> predicate)
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
                    Birthdate = userDtm.Birthdate,
                    PlanId = userDtm.PlanId,
                    MUserRoleId = userDtm.UserRoleId,
                    City = userDtm.City

                };
                Database.Users.Create(user);
                Database.Save();
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

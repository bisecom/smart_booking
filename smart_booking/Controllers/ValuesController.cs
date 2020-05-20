using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.Models;
using smart_booking.Models.user;
using smart_booking.Models.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smart_booking.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        IUnitOfWorkService db;
        public ValuesController(IUnitOfWorkService serv) 
        {
            db = serv;
        }
        //public ValuesController()
        //{

        //}

        //SBContext db = new SBContext();
        ApplicationDbContext dbAuth = new ApplicationDbContext();
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public /*IEnumerable<User>*/ List<string> Get()
        {
            //db.UserRoles.Add(new UserRole { Name = "TestRole" });
            //db.Countries.Add(new Country { Name = "USA", PhonePrefix = "011" });
            //db.Time_zones.Add(new Time_zone { Zone = "TestZone" });
            //db.SaveChanges();

            db.UsersDTM.Create(new UserDTM
            {
                Id = "DfR5DFSV",
                FirstName = "John",
                SecondName = "Doe",
                PhoneMobile = "+00131151531",
                PhoneOffice = "003151351313",
                CountryId = 1,
                UserPicture = null,
                Address = "Pupkina av 12",
                City = "New York",
                State = "NY",
                ZipCode = "3453453345",
                PlanId = 1,
                PaymentOverdue = 0,
                IsMale = true,
                Birthdate = new DateTime(1998, 04, 30),
                Time_ZoneId = 1,
                UserRoleId = 1
            });
            db.SaveChanges();

            List<string> showList = new List<string>();
            //var usersList = db.Users.ToList();
            //for (int i = 0; i < usersList.Count; i++)
            //{
            //    showList.Add(usersList[i].FirstName);
            //    showList.Add(usersList[i].SecondName);
            //}

            //var user = db.Users.SingleOrDefault();
            //string str = user.FirstName + " " + user.SecondName;

            //var user = bdAuth.Users.FirstOrDefault();
            //string userData = user.FirstName + " " + user.Email;

            return /*db.Users*/ showList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

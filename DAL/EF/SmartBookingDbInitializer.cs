using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.EF
{
    public class SmartBookingDbInitializer : CreateDatabaseIfNotExists<SBContext>
    {
        protected override void Seed(SBContext db)
        {
            db.Users.Add(new User
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
                IsPaymentOverdue = false,
                IsMale = true,
                Birthdate = new DateTime(1998, 04, 30),
                Time_ZoneId = 1
            });

            db.Users.Add(new User
            {
                Id = "DfR556WCD",
                FirstName = "Joe",
                SecondName = "Fieldon",
                PhoneMobile = "0013145645645",
                PhoneOffice = "0031513566542",
                CountryId = 1,
                UserPicture = null,
                Address = "Zhukovskogo av 34",
                City = "NY",
                State = "NY",
                ZipCode = "345343332",
                PlanId = 1,
                IsPaymentOverdue = false,
                IsMale = true,
                Birthdate = new DateTime(1995, 10, 30),
                Time_ZoneId = 2
            });

            base.Seed(db);
        }
    }
}
using smart_booking.Models.user;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace smart_booking.Models
{
    public class SmartBookingDbInitializer : CreateDatabaseIfNotExists<SBContext>
    {
        protected override void Seed(SBContext db)
        {
            db.UserRoles.Add(new UserRole { Name = "TestRole" });
            db.Countries.Add(new utils.Country { Name = "USA", FlagImage = null, PhonePrefix = "011" });
            db.Time_zones.Add(new utils.Time_zone { Zone = "TestZone" });

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
                PaymentOverdue = 0,
                IsMale = true,
                Birthdate = new DateTime(1998, 04, 30),
                Time_ZoneId = 1,
                UserRoleId = 1
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
                PaymentOverdue = 0,
                IsMale = true,
                Birthdate = new DateTime(1995, 10, 30),
                Time_ZoneId = 2,
                UserRoleId = 1
            });

            base.Seed(db);
        }
    }
}
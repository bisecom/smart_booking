using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using smart_booking.Models.user;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace smart_booking.Models.database
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "moderator" };
            var role3 = new IdentityRole { Name = "freeMember" };
            var role4 = new IdentityRole { Name = "goldMember" };
            var role5 = new IdentityRole { Name = "platinumMember" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);
            roleManager.Create(role5);

            var freeMember = new ApplicationUser { FirstName = "Igor", Email = "bisecom@ukr.net", UserName = "bisecom@ukr.net" };
            string passwordFree = "111";
            var resultFree = userManager.Create(freeMember, passwordFree);

            var admin = new ApplicationUser { FirstName = "Sergiy", Email = "bisecom@gmail.com", UserName = "bisecom@gmail.com" };
            string password = "111";
            var result = userManager.Create(admin, password);

            if (result.Succeeded && resultFree.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(freeMember.Id, role3.Name);
            }



            

            base.Seed(context);
        }
    }
}
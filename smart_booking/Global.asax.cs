using BLL.Utils;
using smart_booking.Models;
using smart_booking.Models.database;
using smart_booking.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace smart_booking
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<SBContext>(new SmartBookingDbInitializer());
            //Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            AutofacConfig.Configure();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Dependency Ingection
            //NinjectModule orderModule = new DependencyModule();
            //NinjectModule serviceModule = new ServiceModule("SBContext");
            //var kernel = new StandardKernel(orderModule, serviceModule);
            //System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

//System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
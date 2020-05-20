using Autofac;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class AutofacBllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Create our Services
            builder.RegisterType<DalUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}

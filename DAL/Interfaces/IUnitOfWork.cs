using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRepository<MUserRole> MUserRoles { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Country> Countries { get; }
        IRepository<Time_zone> Time_zones { get; }
       
    }
}

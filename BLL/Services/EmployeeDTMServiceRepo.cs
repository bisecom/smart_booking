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
    class EmployeeDTMServiceRepo : IServiceRepository<EmployeeDTM>
    {
        IUnitOfWork Database { get; set; }

        public EmployeeDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<EmployeeDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTM> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeDTM> Find(Func<EmployeeDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(EmployeeDTM item)
        {
            try
            {
                Employee employee = new Employee();
                employee.Business = await Database.Businesses.Get(item.Business.Id);
                employee.BusinessId = item.Business.Id;
                employee.User = await Database.Users.Get(item.User.Id);
                employee.UserId = item.User.Id;
                employee.IsOwner = item.IsOwner;

                employee.CalendarSetting = null;
                employee.CustomerNotification = null;
                employee.TeamNotification = null;
                employee.Permission = null;
                employee.WorkingHour = null;
                employee.Slot = null;

                await Database.Employees.Create(employee);
                return employee.Id;
            }
            catch { return 0; }
        }

        public Task<bool> Update(EmployeeDTM item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                Database.Employees.Delete(id);
                return true;
            }
            catch { return false; }
        }
    }
}

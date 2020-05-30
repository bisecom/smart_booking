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

        public async Task<List<EmployeeDTM>> GetAll(SearchParams search)
        {
            IQueryable<Employee> employeeQuery = Database.Employees.GetAll();
            List<Employee> temp = employeeQuery
            .Where(t => t.BusinessId == search.BusinessId)
            .ToList();
            List<EmployeeDTM> tempList = new List<EmployeeDTM>();

            if (temp != null)
                foreach (var e in temp)
                {
                    tempList.Add(ModelFactory.changeToDTM(e));
                }

            return tempList;
        }

        public async Task<EmployeeDTM> Get(int id)
        {
            int firstEmployeeId = 1;
            if (id < firstEmployeeId)
                throw new ValidationException("Employee id is not specified correctly", "");
            var employee = await Database.Employees.Get(id);
            if (employee == null)
                throw new ValidationException("Employee is not found", "");

            EmployeeDTM employeeDTM = ModelFactory.changeToDTM(employee);
            return employeeDTM;
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

        public async Task<bool> Update(EmployeeDTM employeeDtm)
        {
            //try
            //{
            //    Employee employee = new Employee();
            //    if (employeeDtm.User != null)
            //    {
            //        employee.User = changeToDTM(employee.User);
            //        employee.UserId = employee.User.Id;
            //    }
            //    employee.IsOwner = employeeDtm.IsOwner;

            //    if (employeeDtm.CalendarSetting != null)
            //    {
            //        employee.CalendarSetting = changeToDTM(employee.CalendarSetting);
            //    }

            //    if (employeeDtm.CustomerNotification != null)
            //    {
            //        employee.CustomerNotification = changeToDTM(employee.CustomerNotification);
            //    }
            //    if (employeeDtm.TeamNotification != null)
            //    {
            //        employee.TeamNotification = changeToDTM(employee.TeamNotification);
            //    }
            //    if (employeeDtm.Permission != null)
            //    {
            //        employee.Permission = changeToDTM(employee.Permission);
            //    }
            //    if (employeeDtm.WorkingHour != null)
            //    {
            //        employee.WorkingHour = changeToDTM(employee.WorkingHour);
            //    }
            //    if (employeeDtm.Slot != null)
            //    {
            //        employee.Slot = changeToDTM(employee.Slot);
            //    }

            //    return await Database.Employees.Update(employee) ? true : false;
            //}
            //catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
            return false;
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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

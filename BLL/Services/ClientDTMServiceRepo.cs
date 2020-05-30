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
    public class ClientDTMServiceRepo : IServiceRepository<ClientDTM>
    {
        IUnitOfWork Database { get; set; }

        public ClientDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ClientDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDTM> Get(int id)
        {
            int firstClientId = 1;
            if (id < firstClientId)
                throw new ValidationException("Client id is not specified correctly", "");
            var client = await Database.Clients.Get(id);
            if (client == null)
                throw new ValidationException("Client is not found", "");

            ClientDTM clientDTM = ClientToClientDTMMap(client);
            return clientDTM;
        }

        public IQueryable<ClientDTM> Find(Func<ClientDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ClientDTM clientDtm)
        {
            try
            {
                Client client = new Client();
                client.Id = clientDtm.Id;
                client.FirstName = clientDtm.FirstName;
                client.SecondName = clientDtm.SecondName;
                client.ClientCompanyName = clientDtm.ClientCompanyName;
                client.Email = clientDtm.Email;
                client.MobilePhone = clientDtm.MobilePhone;
                client.OfficePhone = clientDtm.OfficePhone;
                client.Address = clientDtm.Address;
                client.City = clientDtm.City;
                client.State = clientDtm.State;
                client.Zip_Code = clientDtm.Zip_Code;
                client.BirthDay = clientDtm.BirthDay;
                client.Image = clientDtm.Image;
                client.IsMale = clientDtm.IsMale;
                client.Note = clientDtm.Note;

                client.Business = await Database.Businesses.Get(clientDtm.Business.Id);
                await Database.Clients.Create(client);
                return client.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(ClientDTM clientDtm)
        {
            try
            {
                Client client = new Client();
                client.Id = clientDtm.Id;
                client.FirstName = clientDtm.FirstName;
                client.SecondName = clientDtm.SecondName;
                client.ClientCompanyName = clientDtm.ClientCompanyName;
                client.Email = clientDtm.Email;
                client.MobilePhone = clientDtm.MobilePhone;
                client.OfficePhone = clientDtm.OfficePhone;
                client.Address = clientDtm.Address;
                client.City = clientDtm.City;
                client.State = clientDtm.State;
                client.Zip_Code = clientDtm.Zip_Code;
                client.BirthDay = clientDtm.BirthDay;
                client.Image = clientDtm.Image;
                client.IsMale = clientDtm.IsMale;
                client.Note = clientDtm.Note;
                client.BusinessId = clientDtm.Business.Id;

                client.Business = await Database.Businesses.Get(clientDtm.Business.Id);

                return await Database.Clients.Update(client) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Database.Clients.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public ClientDTM ClientToClientDTMMap(Client client)
        {
            ClientDTM clientDtm = new ClientDTM();
            clientDtm.Id = client.Id;
            clientDtm.FirstName = client.FirstName;
            clientDtm.SecondName = client.SecondName;
            clientDtm.ClientCompanyName = client.ClientCompanyName;
            clientDtm.Email = client.Email;
            clientDtm.MobilePhone = client.MobilePhone;
            clientDtm.OfficePhone = client.OfficePhone;
            clientDtm.Address = client.Address;
            clientDtm.City = client.City;
            clientDtm.State = client.State;
            clientDtm.Zip_Code = client.Zip_Code;
            clientDtm.BirthDay = client.BirthDay;
            clientDtm.Image = client.Image;
            clientDtm.IsMale = client.IsMale;
            clientDtm.Note = client.Note;
            clientDtm.BusinessId = client.Business.Id;

            return clientDtm;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

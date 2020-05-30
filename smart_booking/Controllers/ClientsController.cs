using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class ClientsController : BaseApiController
    {
        public ClientsController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/Clients/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var client = await TheRepo.ClientsDTM.Get(id);
                if (client != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, client);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Clients/client
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]ClientDTM clientDtm)
        {
            try
            {
                var originalClient = TheRepo.ClientsDTM.Get(clientDtm.Id);

                if (originalClient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.ClientsDTM.Update(clientDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, clientDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Clients/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalClient = TheRepo.ClientsDTM.Get(id);
                if (originalClient == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.ClientsDTM.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Clients/clientDtm
        public async Task<HttpResponseMessage> Post([FromBody] ClientDTM clientDtm)
        {
            try
            {
                int id = await TheRepo.ClientsDTM.Create(clientDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}

using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class UserController : ApiController
    {
        IUnitOfWorkService dbRepository;
        public UserController(IUnitOfWorkService serv)
        {
            dbRepository = serv;
        }

        //// GET: api/Users
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        public HttpResponseMessage Get(string userId)
        {
            try
            {
                var user = dbRepository.UsersDTM.Get(userId);
                if (user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
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

        public HttpResponseMessage Post([FromBody] UserDTM userDtm)
        {
            try
            {
                if (dbRepository.UsersDTM.Create(userDtm))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, userDtm);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //// PUT: api/Users/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Users/5
        //public void Delete(int id)
        //{
        //}
    }
}

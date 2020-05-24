using BLL.Interfaces;
using BLL.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using smart_booking.BLL.DataTransferModels;
using smart_booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/Users
        public async Task<List<UserDTM>> Get(SearchParams mSearch)
        {
            List<UserDTM> query = await TheRepo.UsersDTM.GetAll(mSearch);
            return query;
        }

        // GET: api/Users/string
        public async Task<HttpResponseMessage> Get(string id)
        {
            try
            {
                var user = await TheRepo.UsersDTM.Get(id);
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
        
        // POST: api/Users/userDTM
        public HttpResponseMessage Post([FromBody] UserDTM userDtm)
        {
            //try
            //{
            //    if (TheRepo.UsersDTM.Create(userDtm))
            //    {
            //        return Request.CreateResponse(HttpStatusCode.Created, userDtm);
            //    }
            //    else
            //    {
            //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}

            // create account via POST api/Account/Register 
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
        }

        // PUT: api/Users/userDTM
        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]UserDTM userDTM)
        {
            try
            {
                var originalUser = TheRepo.UsersDTM.Get(userDTM.Id);

                if (originalUser == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "User is not found");
                }
                else
                {
                    TheRepo.UsersDTM.Update(userDTM);
                    return Request.CreateResponse(HttpStatusCode.OK, userDTM);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Users/sdfsds
        public async Task<HttpResponseMessage> Delete(string id)
        {
            // deleting via api/account/sdfsds
            return Request.CreateResponse(HttpStatusCode.NotModified, "User is not found");
        }
    }
}

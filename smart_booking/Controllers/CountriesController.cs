﻿using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class CountriesController : BaseApiController
    {
        public CountriesController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/Countries/1
        public HttpResponseMessage Get(int id)
        {
            //try
            //{
            //    var country = TheRepo.CountriesDTM.Get(id);
            //    if (country != null)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.OK, country);
            //    }
            //    else
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}

            SeedDbUponRequest seed = new SeedDbUponRequest();
            
            //foreach(var country in seed.ZonesListDtm)
            //{
            //    TheRepo.z.Create(country);
            //}
                           
                return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
        // POST: api/Countries/countryDtm
        public HttpResponseMessage Post([FromBody] CountryDTM countryDtm)
        {
            try
            {
                if (TheRepo.CountriesDTM.Create(countryDtm))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, countryDtm);
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
    }
}
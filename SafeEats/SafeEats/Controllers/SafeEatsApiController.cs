using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SafeEats.Controllers
{
    public class SafeEatsApiController : ApiController
    {
        // GET: api/SafeEatsApi
        
        public ActionResult Get()
        {
            //JsonSerializer 
            List<string> list_of_strings = new List<string>();
            list_of_strings.Add("Hello");
            list_of_strings.Add("Goodbye");
            JsonResult response = new JsonResult();
            //response.
            response.Data = list_of_strings;
            response.ContentType = "application/json";
            return response;
        }

        // GET: api/SafeEatsApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SafeEatsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SafeEatsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SafeEatsApi/5
        public void Delete(int id)
        {
        }
    }
}

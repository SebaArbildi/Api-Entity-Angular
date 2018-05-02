using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class MarginController : ApiController
    {
        // GET: api/Margin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Margin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Margin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Margin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Margin/5
        public void Delete(int id)
        {
        }
    }
}

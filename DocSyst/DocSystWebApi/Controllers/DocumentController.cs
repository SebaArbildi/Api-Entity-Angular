using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class DocumentController : ApiController
    {
        // GET: api/Document
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Document/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Document
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Document/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Document/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class ParagraphController : ApiController
    {
        // GET: api/Paragraph
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Paragraph/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Paragraph
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Paragraph/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Paragraph/5
        public void Delete(int id)
        {
        }
    }
}

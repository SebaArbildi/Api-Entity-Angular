using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class StyleController : ApiController
    {
        // GET: api/Style
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET: api/Style/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/Style
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok();

        }

        // PUT: api/Style/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();

        }

        // DELETE: api/Style/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();

        }
    }
}

using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class SpecificStyleController : ApiController
    {
        private ISpecificStyleBusinessLogic SpecificStyleBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public SpecificStyleController(ISpecificStyleBusinessLogic specificStyleBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            SpecificStyleBusinessLogic = specificStyleBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/SpecificStyle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SpecificStyle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpecificStyle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SpecificStyle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpecificStyle/5
        public void Delete(int id)
        {
        }
    }
}

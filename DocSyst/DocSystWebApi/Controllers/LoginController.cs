using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class LoginController : ApiController
    {
        private ILoginBusinessLogic LoginBusinessLogic { get; set; }

        public LoginController(ILoginBusinessLogic LoginBusinessLogic)
        {
            this.LoginBusinessLogic = LoginBusinessLogic;
        }

        public IHttpActionResult Put([FromBody]string username, [FromBody]string password)
        {
            try
            {
                Guid token = LoginBusinessLogic.Login(username, password);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystWebApi.Models.UserModel;
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

        [Route("api/Login", Name = "Login")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] UserModel user)
        {
            try
            {
                Guid token = LoginBusinessLogic.Login(user.Username, user.Password);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
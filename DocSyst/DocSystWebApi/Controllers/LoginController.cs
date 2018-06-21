using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystEntities.User;
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
        private IUserBusinessLogic UserBusinessLogic { get; set; }

        public LoginController(ILoginBusinessLogic LoginBusinessLogic, IUserBusinessLogic userBusinessLogic)
        {
            this.LoginBusinessLogic = LoginBusinessLogic;
            this.UserBusinessLogic = userBusinessLogic;
        }

        [Route("api/Login", Name = "Login")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] UserModel user)
        {
            try
            {
                Guid token = LoginBusinessLogic.Login(user.Username, user.Password);
                User obtainedUser = UserBusinessLogic.GetUser(user.Username);
                UserModel responseUser = UserModel.ToModel(obtainedUser);
                return Ok(responseUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
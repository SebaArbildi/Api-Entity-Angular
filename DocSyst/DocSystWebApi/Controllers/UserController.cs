using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystEntities.User;
using DocSystWebApi.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserBusinessLogic UserBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public UserController(IUserBusinessLogic userBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            UserBusinessLogic = userBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/User
        public IHttpActionResult Get()
        {
           try
           {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                IList<User> users = UserBusinessLogic.GetUsers();
                IList<UserModel> usersModel = ConvertEntitiesToModels(users);
                return Ok(usersModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/User/5
        public IHttpActionResult Get([FromUri] string username)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                User user = UserBusinessLogic.GetUser(username);
                return Ok(UserModel.ToModel(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]UserModel userModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                UserBusinessLogic.AddUser(userModel.ToEntity());
                return Ok("User added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/User/5
        public IHttpActionResult Put([FromUri] string username, [FromBody]UserModel userModel)
        {
            try
            {
                userModel.Username = username;
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                UserBusinessLogic.ModifyUser(userModel.ToEntity());
                return Ok("User Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete([FromUri] string username)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                UserBusinessLogic.DeleteUser(username);
                return Ok("User deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private IList<UserModel> ConvertEntitiesToModels(IList<User> users)
        {
            IList<UserModel> usersModels = new List<UserModel>();
            foreach(User user in users)
            {
                usersModels.Add(UserModel.ToModel(user));
            }
            return usersModels;
        }
    }
}

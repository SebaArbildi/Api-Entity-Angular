using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystEntities.User;
using DocSystWebApi.Filters;
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

        public UserController(IUserBusinessLogic userBusinessLogic)
        {
            UserBusinessLogic = userBusinessLogic;
        }

        // GET: api/User
        public IHttpActionResult Get()
        {
            try
            {
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
                UserBusinessLogic.AddUser(userModel.ToEntity());
                return Ok("User added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/User/5
        public IHttpActionResult Put([FromBody]UserModel userModel)
        {
            try
            {
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

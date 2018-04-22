﻿using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
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
        private IUserBusinessLogic userBusinessLogic;

        public UserController(IUserBusinessLogic userBusinessLogic)
        {
            this.userBusinessLogic = userBusinessLogic;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public IHttpActionResult Get([FromUri] string username)
        {
            try
            {
                User user = this.userBusinessLogic.GetUser(username);
                return Ok(UserModel.ToModel(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

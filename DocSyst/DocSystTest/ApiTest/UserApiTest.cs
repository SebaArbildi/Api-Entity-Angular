<<<<<<< HEAD
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystWebApi.Controllers;
using DocSystEntities.User;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using System.Web.Http;
using DocSystWebApi.Models.UserModel;
using System;
using System.Collections.Generic;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using System.Web.Http.Results;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class UserApiTest
    {
        private UserModel userModel;
        private User user;
        private Mock<IUserBusinessLogic> mockUserBusinessLogic;
        private UserController userController;

=======
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystWebApi.Controllers;
using DocSystEntities.User;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using System.Web.Http;
using DocSystWebApi.Models.UserModel;
using System;
using System.Collections.Generic;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using System.Web.Http.Results;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using System.Net.Http;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class UserApiTest
    {
        private UserModel userModel;
        private User user;
        private Mock<IUserBusinessLogic> mockUserBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockUserAuthorizationLogic;
        private UserController userController;


>>>>>>> develop
        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
<<<<<<< HEAD
        }

        [TestInitialize]
        public void TestInitialize()
        {
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            mockUserBusinessLogic = new Mock<IUserBusinessLogic>();
            userController = new UserController(mockUserBusinessLogic.Object);
        }

        [TestMethod]
        public void CreateUserController_WithParameters_Ok()
        {
            Assert.IsNotNull(userController);
        }

        [TestMethod]
        public void GetUser_UserExists_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.GetUser(user.Username)).Returns(user);
            IHttpActionResult statusObtained = userController.Get(user.Username);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<UserModel>);
        }

        [TestMethod]
        public void GetUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.GetUser(user.Username)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Get(user.Username);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<UserModel>);
        }

        [TestMethod]
        public void AddUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.AddUser(user));
            IHttpActionResult statusObtained = userController.Post(userModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.AddUser(user)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Post(userModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetUsers_ExpectedParameters_Ok()
        {
            IList<User> users = new List<User>
            {
                user
            };
            mockUserBusinessLogic.Setup(b1 => b1.GetUsers()).Returns(users);
            IHttpActionResult statusObtained = userController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<UserModel>>);
        }

        [TestMethod]
        public void GetUsers_BadRequest_Exception()
        {
            IList<UserModel> usersModel = new List<UserModel>
            {
                userModel
            };
            mockUserBusinessLogic.Setup(b1 => b1.GetUsers()).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<UserModel>>);
        }

        [TestMethod]
        public void ModifyUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.ModifyUser(user));
            IHttpActionResult statusObtained = userController.Put(userModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyUser_BadRequest_Exception()
        {
            IList<UserModel> usersModel = new List<UserModel>
            {
                userModel
            };
            mockUserBusinessLogic.Setup(b1 => b1.ModifyUser(user)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Put(userModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.DeleteUser(user.Username));
            IHttpActionResult statusObtained = userController.Delete(user.Username);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.DeleteUser(user.Username)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Delete(user.Username);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            UserBusinessLogic userBL = new UserBusinessLogic(new UserDataAccess());
            UserController userC = new UserController(userBL);
            UserModel user2 = UserModel.ToModel(Utils.CreateUserForTest());
            userC.Post(userModel);
            userC.Post(user2);
            user2.Name = "modified";
            userC.Put(user2);
            userC.Delete(userModel.Username);
            IHttpActionResult statusObtained = userC.Get();
        }
    }
}
=======
        }

        [TestInitialize]
        public void TestInitialize()
        {
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            mockUserAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockUserBusinessLogic = new Mock<IUserBusinessLogic>();
            userController = new UserController(mockUserBusinessLogic.Object, mockUserAuthorizationLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", user.Token + "");
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(user.Token)).Returns(true);
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(user.Token)).Returns(true);
            userController.Request = requestMessage;
        }

        [TestMethod]
        public void CreateUserController_WithParameters_Ok()
        {
            Assert.IsNotNull(userController);
        }

        [TestMethod]
        public void GetUser_UserExists_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.GetUser(user.Username)).Returns(user);
            IHttpActionResult statusObtained = userController.Get(user.Username);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<UserModel>);
        }

        [TestMethod]
        public void GetUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.GetUser(user.Username)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Get(user.Username);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<UserModel>);
        }

        [TestMethod]
        public void AddUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.AddUser(user));
            IHttpActionResult statusObtained = userController.Post(userModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.AddUser(user)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Post(userModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetUsers_ExpectedParameters_Ok()
        {
            IList<User> users = new List<User>();
            users.Add(user);
            mockUserBusinessLogic.Setup(b1 => b1.GetUsers()).Returns(users);
            IHttpActionResult statusObtained = userController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<UserModel>>);
        }

        [TestMethod]
        public void GetUsers_BadRequest_Exception()
        {
            IList<UserModel> usersModel = new List<UserModel>();
            usersModel.Add(userModel);
            mockUserBusinessLogic.Setup(b1 => b1.GetUsers()).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<UserModel>>);
        }

        [TestMethod]
        public void ModifyUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.ModifyUser(user));
            IHttpActionResult statusObtained = userController.Put(userModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyUser_BadRequest_Exception()
        {
            IList<UserModel> usersModel = new List<UserModel>();
            usersModel.Add(userModel);
            mockUserBusinessLogic.Setup(b1 => b1.ModifyUser(user)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Put(userModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.DeleteUser(user.Username));
            IHttpActionResult statusObtained = userController.Delete(user.Username);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.DeleteUser(user.Username)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Delete(user.Username);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            var requestMessage = new HttpRequestMessage();
            IUserDataAccess da = new UserDataAccess();
            IUserBusinessLogic userBL = new UserBusinessLogic(new UserDataAccess());
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(da);
            UserController userC = new UserController(userBL, auth);
            userC.Request = requestMessage;
            UserModel user2 = UserModel.ToModel(Utils.CreateUserForTest());
            userC.Post(userModel);
            userC.Post(user2);
            user2.Name = "modified";
            userC.Put(user2);
            userC.Delete(userModel.Username);
            IHttpActionResult statusObtained = userC.Get();
        }
    }
}
>>>>>>> develop

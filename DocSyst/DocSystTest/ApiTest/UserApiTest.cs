using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystWebApi.Controllers;
using DocSystEntities.User;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using System.Web.Http;
using DocSystWebApi.Models.UserModel;
using System;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class UserApiTest
    {
        private UserModel userModel;
        private User user;
        private Mock<IUserBusinessLogic> mockUserBusinessLogic;
        private UserController userController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
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
        }

        [TestMethod]
        public void GetUser_BadRequest_Exception()
        {
            mockUserBusinessLogic.Setup(b1 => b1.GetUser(user.Username)).Throws(new Exception());
            IHttpActionResult statusObtained = userController.Get(user.Username);
        }

        [TestMethod]
        public void AddUser_ExpectedParameters_Ok()
        {
            mockUserBusinessLogic.Setup(b1 => b1.AddUser(user));
            userController.Post(userModel);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystWebApi.Controllers;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class UserApiTest
    {
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
            mockUserBusinessLogic = new Mock<IUserBusinessLogic>();
            userController = new UserController(mockUserBusinessLogic.Object);
        }

        [TestMethod]
        public void CreateUserController_WithParameters_Ok()
        {
            Assert.IsNotNull(userController);
        }
    }
}

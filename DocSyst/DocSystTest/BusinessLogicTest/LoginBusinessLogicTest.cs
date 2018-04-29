using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class LoginBusinessLogicTest
    {

        private Mock<IUserDataAccess> mockUserDataAccess;
        private ILoginBusinessLogic loginBusinessLogic;
        private User user;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockUserDataAccess = new Mock<IUserDataAccess>();
            loginBusinessLogic = new LoginBusinessLogic(mockUserDataAccess.Object);
            user = Utils.CreateUserForTest();
        }


        [TestMethod]
        public void Login_validParameters_Ok()
        {
            loginBusinessLogic.Login(user.Username, user.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_notValidParameters_Ok()
        {
            loginBusinessLogic.Login(user.Username, "asdf");
        }
    }
}

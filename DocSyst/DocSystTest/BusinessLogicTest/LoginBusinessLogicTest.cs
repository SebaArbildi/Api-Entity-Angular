using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystDataAccessImplementation.UserDataAccessImplementation;

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
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);
            mockUserDataAccess.Setup(b1 => b1.Get(user.Username)).Returns(user);
            mockUserDataAccess.Setup(b1 => b1.Modify(user));
            loginBusinessLogic.Login(user.Username, user.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_notValidParameters_Ok()
        {
            loginBusinessLogic.Login(user.Username, "asdf");
        }

        [TestMethod]
        public void LoginIntegrationTest_validParameters_Ok()
        {
            IUserDataAccess da = new UserDataAccess();
            ILoginBusinessLogic login = new LoginBusinessLogic(da);
            Guid guid = user.Token;

            da.Add(user);
            login.Login(user.Username, user.Password);
            Guid tokenObtained = da.Get(user.Username).Token;
            Assert.AreNotEqual(guid, tokenObtained);
        }
    }
}

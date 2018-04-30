using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using Moq;
using DocSystEntities.User;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using System;
using DocSystDataAccessImplementation.UserDataAccessImplementation;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class AuthorizationBusinessLogicTest
    {

        private Mock<IUserDataAccess> mockUserDataAccess;
        private IAuthorizationBusinessLogic authorizationBusinessLogic;
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
            authorizationBusinessLogic = new AuthorizationBusinessLogic(mockUserDataAccess.Object);
            user = Utils.CreateUserForTest();
        }

        [TestMethod]
        public void TokenIsValid_validToken_True()
        {
            mockUserDataAccess.Setup(b1 => b1.Get(user.Token)).Returns(user);
            Assert.IsTrue(authorizationBusinessLogic.IsAValidToken(user.Token));
        }

        [TestMethod]
        public void TokenIsValid_notValidToken_False()
        {
            mockUserDataAccess.Setup(b1 => b1.Get(user.Token));
            Assert.IsFalse(authorizationBusinessLogic.IsAValidToken(Guid.NewGuid()));
        }

        [TestMethod]
        public void UserIsAdmin_adminUser_True()
        {
            mockUserDataAccess.Setup(b1 => b1.Get(user.Token)).Returns(user);
            Assert.IsTrue(authorizationBusinessLogic.IsAdmin(user.Token));
        }

        [TestMethod]
        public void UserIsAdmin_notAdminUser_False()
        {
            mockUserDataAccess.Setup(b1 => b1.Get(user.Token));
            Assert.IsFalse(authorizationBusinessLogic.IsAdmin(Guid.NewGuid()));
        }

        [TestMethod]
        public void AuthIntegtrationTest_ExpectedValues_Ok()
        {
            IUserDataAccess da = new UserDataAccess();
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(da);
            user.IsAdmin = true;

            da.Add(user);
            Assert.IsTrue(auth.IsAdmin(user.Token));
            Assert.IsTrue(auth.IsAValidToken(user.Token));
            Assert.IsFalse(auth.IsAValidToken(Guid.NewGuid()));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using Moq;
using DocSystEntities.User;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;

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
            authorizationBusinessLogic = new authorizationBusinessLogic(mockUserDataAccess.Object);
            user = Utils.CreateUserForTest();
        }

        [TestMethod]
        public void TokenIsValid_validToken_Ok()
        {

        }

        [TestMethod]
        public void TokenIsValid_notValidToken_throwException()
        {

        }

        [TestMethod]
        public void UserIsAdmin_adminUser_Ok()
        {

        }

        [TestMethod]
        public void UserIsAdmin_notAdminUser_throwException()
        {

        }
    }
}

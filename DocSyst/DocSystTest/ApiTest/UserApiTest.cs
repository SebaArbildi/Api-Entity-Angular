using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystWebApi.Controllers;
using DocSystEntities.User;
using System.Web.Http;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class UserApiTest
    {
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
    }
}

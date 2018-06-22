using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.User;
using DocSystWebApi.Controllers;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class LoginControllerTest
    {
        private User user;
        private Mock<ILoginBusinessLogic> loginBusinessLogic;
        private LoginController loginController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        /*[TestInitialize]
        public void TestInitialize()
        {
            user = Utils.CreateUserForTest();
            loginBusinessLogic = new Mock<ILoginBusinessLogic>();
            loginController = new LoginController(loginBusinessLogic.Object);
        }*/

        /*[TestMethod]
        public void Login_ExpectedParameters_Ok()
        {
            loginBusinessLogic.Setup(b1 => b1.Login(user.Username, user.Password)).Returns(user.Token);
            IHttpActionResult statusObtained = loginController.Put(user.Username, user.Password);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<Guid>);

        }

        [TestMethod]
        public void Login_NonExpectedParameters_Exception()
        {
            loginBusinessLogic.Setup(b1 => b1.Login(user.Username, user.Password)).Throws(new Exception());
            IHttpActionResult statusObtained = loginController.Put(user.Username, user.Password);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<Guid>);
        }*/
    }
}

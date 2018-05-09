using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using Moq;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystEntities.StyleStructure;
using DocSystWebApi.Models.StyleStructureModels;
using DocSystWebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace DocSystTest.ApiTest.StyleStructureApiTest
{
    [TestClass]
    public class StyleControllerTest
    {
        private StyleModel styleModel;
        private Style style;
        private Mock<IStyleBusinessLogic> mockStyleBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockUserAuthorizationLogic;
        private StyleController styleController;


        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            style = Utils.CreateStyleForTest();
            styleModel = StyleModel.ToModel(style);
            mockUserAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockStyleBusinessLogic = new Mock<IStyleBusinessLogic>();
            styleController = new StyleController(mockStyleBusinessLogic.Object, mockUserAuthorizationLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            Guid token = Guid.NewGuid();
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", token + "");
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(token)).Returns(true);
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(token)).Returns(true);
            styleController.Request = requestMessage;
        }

        [TestMethod]
        public void GetStyle_ExpectedParameters_Ok()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Get(style.Name)).Returns(style);
            IHttpActionResult statusObtained = styleController.Get(style.Name);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<StyleModel>);
        }

        [TestMethod]
        public void GetStyle_BadRequest_Exception()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Get(style.Name)).Throws(new Exception());
            IHttpActionResult statusObtained = styleController.Get(style.Name);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<SpecificStyleModel>);
        }

        [TestMethod]
        public void AddStyle_ExpectedParameters_Ok()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Add(style));
            IHttpActionResult statusObtained = styleController.Post(styleModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddStyle_BadRequest_Exception()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Add(style)).Throws(new Exception());
            IHttpActionResult statusObtained = styleController.Post(styleModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetStyles_ExpectedParameters_Ok()
        {
            IList<Style> styles = new List<Style>();
            styles.Add(style);
            mockStyleBusinessLogic.Setup(b1 => b1.Get()).Returns(styles);
            IHttpActionResult statusObtained = styleController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<StyleModel>>);
        }

        [TestMethod]
        public void GetStyles_BadRequest_Exception()
        {
            IList<Style> styles = new List<Style>();
            styles.Add(style);
            mockStyleBusinessLogic.Setup(b1 => b1.Get()).Throws(new Exception());
            IHttpActionResult statusObtained = styleController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<StyleModel>>);
        }

        [TestMethod]
        public void ModifyStyle_ExpectedParameters_Ok()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Modify(style));
            IHttpActionResult statusObtained = styleController.Put(styleModel.Name, styleModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyStyle_BadRequest_Exception()
        {
            IList<StyleModel> stylesModel = new List<StyleModel>();
            stylesModel.Add(styleModel);
            mockStyleBusinessLogic.Setup(b1 => b1.Modify(style)).Throws(new Exception());
            IHttpActionResult statusObtained = styleController.Put(styleModel.Name, styleModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteStyle_ExpectedParameters_Ok()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Delete(style.Name));
            IHttpActionResult statusObtained = styleController.Delete(style.Name);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteStyle_BadRequest_Exception()
        {
            mockStyleBusinessLogic.Setup(b1 => b1.Delete(style.Name)).Throws(new Exception());
            IHttpActionResult statusObtained = styleController.Delete(style.Name);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }
    }
}

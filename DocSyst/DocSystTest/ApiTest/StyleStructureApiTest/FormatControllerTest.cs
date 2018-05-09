using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using Moq;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using DocSystWebApi.Models.StyleStructureModels;
using DocSystWebApi.Controllers;

namespace DocSystTest.ApiTest.StyleStructureApiTest
{
    [TestClass]
    public class FormatControllerTest
    {
        private FormatModel formatModel;
        private Format format;
        private Mock<IFormatBusinessLogic> mockFormatsBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockUserAuthorizationLogic;
        private FormatController formatController;
        private StyleClass styleClass;


        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            styleClass = Utils.CreateStyleClassForTest();
            format = Utils.CreateFormatForTest();
            formatModel = FormatModel.ToModel(format);
            mockUserAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockFormatsBusinessLogic = new Mock<IFormatBusinessLogic>();
            formatController = new FormatController(mockFormatsBusinessLogic.Object, mockUserAuthorizationLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            Guid token = Guid.NewGuid();
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", token + "");
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(token)).Returns(true);
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(token)).Returns(true);
            formatController.Request = requestMessage;
        }

        [TestMethod]
        public void GetFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Get(format.Id)).Returns(format);
            IHttpActionResult statusObtained = formatController.Get(format.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<FormatModel>);
        }

        [TestMethod]
        public void GetFormat_BadRequest_Exception()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Get(format.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.Get(format.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<FormatModel>);
        }

        [TestMethod]
        public void AddFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Add(format));
            IHttpActionResult statusObtained = formatController.Post(formatModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddFormat_BadRequest_Exception()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Add(format)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.Post(formatModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetFormats_ExpectedParameters_Ok()
        {
            IList<Format> specificStyles = new List<Format>();
            specificStyles.Add(format);
            mockFormatsBusinessLogic.Setup(b1 => b1.Get()).Returns(specificStyles);
            IHttpActionResult statusObtained = formatController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<FormatModel>>);
        }

        [TestMethod]
        public void GetFormats_BadRequest_Exception()
        {
            IList<Format> formats = new List<Format>();
            formats.Add(format);
            mockFormatsBusinessLogic.Setup(b1 => b1.Get()).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<FormatModel>>);
        }

        [TestMethod]
        public void ModifyFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Modify(format));
            IHttpActionResult statusObtained = formatController.Put(formatModel.Id, formatModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyFormat_BadRequest_Exception()
        {
            IList<FormatModel> specificStylesModel = new List<FormatModel>();
            specificStylesModel.Add(formatModel);
            mockFormatsBusinessLogic.Setup(b1 => b1.Modify(format)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.Put(formatModel.Id, formatModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Delete(format.Id));
            IHttpActionResult statusObtained = formatController.Delete(format.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteFormat_BadRequest_Exception()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.Delete(format.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.Delete(format.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddStyleClassToFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.AddStyle(format.Id, styleClass));
            IHttpActionResult statusObtained = formatController.AddStyleToStyleClass(format.Id, StyleClassModel.ToModel(styleClass));
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddStyleClassToFormat_BadRequest_Exception()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.AddStyle(format.Id, styleClass)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.AddStyleToStyleClass(format.Id, StyleClassModel.ToModel(styleClass));
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_ExpectedParameters_Ok()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.RemoveStyle(format.Id, styleClass.Id));
            IHttpActionResult statusObtained = formatController.RemoveStyleFromStyleClass(format.Id, styleClass.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_BadRequest_Exception()
        {
            mockFormatsBusinessLogic.Setup(b1 => b1.RemoveStyle(format.Id, styleClass.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = formatController.RemoveStyleFromStyleClass(format.Id, styleClass.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }
    }
}

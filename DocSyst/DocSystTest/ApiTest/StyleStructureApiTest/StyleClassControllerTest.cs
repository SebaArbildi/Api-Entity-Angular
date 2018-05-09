using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using Moq;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System.Net.Http;
using DocSystWebApi.Models.StyleStructureModels;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace DocSystTest.ApiTest.StyleStructureApiTest
{
    [TestClass]
    public class StyleClassControllerTest
    {
        public HttpRequestMessage Request { get; private set; }

        public class SpecificStyleControllerTest
        {
            private StyleClassModel styleClassModel;
            private StyleClass styleClass;
            private Mock<IStyleClassBusinessLogic> mockStyleClassBusinessLogic;
            private Mock<IAuthorizationBusinessLogic> mockUserAuthorizationLogic;
            private StyleClassControllerTest StyleClassController;
            private Style style;


            [TestCleanup]
            public void CleanDataBase()
            {
                Utils.DeleteBd();
            }

            [TestInitialize]
            public void TestInitialize()
            {
                style = Utils.CreateStyleForTest();
                styleClass = Utils.CreateStyleClassForTest();
                styleClassModel = StyleClassModel.ToModel(styleClass);
                mockUserAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
                mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
                StyleClassController = new StyleClassController(mockStyleClassBusinessLogic.Object, mockUserAuthorizationLogic.Object);
                InitializeToken();
            }

            private void InitializeToken()
            {
                Guid token = Guid.NewGuid();
                var requestMessage = new HttpRequestMessage();
                requestMessage.Headers.Add("Token", token + "");
                mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(token)).Returns(true);
                mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(token)).Returns(true);
                StyleClassController.Request = requestMessage;
            }

            [TestMethod]
            public void GetStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
                IHttpActionResult statusObtained = StyleClassController.Get(styleClass.Id);
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<StyleClassModel>);
            }

            [TestMethod]
            public void GetStyleClass_BadRequest_Exception()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Get(styleClass.Id)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.Get(styleClass.Id);
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<StyleClassModel>);
            }

            [TestMethod]
            public void AddStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Add(styleClass));
                IHttpActionResult statusObtained = StyleClassController.Post(styleClassModel);
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void AddStyleClass_BadRequest_Exception()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Add(styleClass)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.Post(styleClassModel);
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void GetStyleClasses_ExpectedParameters_Ok()
            {
                IList<StyleClass> specificStyles = new List<StyleClass>();
                specificStyles.Add(styleClass);
                mockStyleClassBusinessLogic.Setup(b1 => b1.Get()).Returns(specificStyles);
                IHttpActionResult statusObtained = StyleClassController.Get();
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<StyleClassModel>>);
            }

            [TestMethod]
            public void GetStyleClasses_BadRequest_Exception()
            {
                IList<StyleClass> specificStyles = new List<StyleClass>();
                specificStyles.Add(styleClass);
                mockStyleClassBusinessLogic.Setup(b1 => b1.Get()).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.Get();
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<StyleClassModel>>);
            }

            [TestMethod]
            public void ModifyStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Modify(styleClass));
                IHttpActionResult statusObtained = StyleClassController.Put(styleClassModel.Id, styleClassModel);
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void ModifyStyleClass_BadRequest_Exception()
            {
                IList<StyleClassModel> specificStylesModel = new List<StyleClassModel>();
                specificStylesModel.Add(styleClassModel);
                mockStyleClassBusinessLogic.Setup(b1 => b1.Modify(styleClass)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.Put(styleClassModel.Id, styleClassModel);
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void DeleteStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Delete(styleClass.Id));
                IHttpActionResult statusObtained = StyleClassController.Delete(styleClass.Id);
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void DeleteStyleClass_BadRequest_Exception()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.Delete(styleClass.Id)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.Delete(styleClass.Id);
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void AddStyleToStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.AddStyle(styleClass.Id, style));
                IHttpActionResult statusObtained = StyleClassController.AddStyle(styleClass.Id, StyleModel.ToModel(style));
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void AddStyleToStyleClass_BadRequest_Exception()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.AddStyle(styleClass.Id, style)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.AddStyle(styleClass.Id, StyleModel.ToModel(style));
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void RemoveStyleFromStyleClass_ExpectedParameters_Ok()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.RemoveStyle(styleClass.Id, style.Name));
                IHttpActionResult statusObtained = StyleClassController.RemoveStyle(styleClass.Id, style.Name);
                Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
            }

            [TestMethod]
            public void RemoveStyleFromStyleClass_BadRequest_Exception()
            {
                mockStyleClassBusinessLogic.Setup(b1 => b1.RemoveStyle(styleClass.Id, style.Name)).Throws(new Exception());
                IHttpActionResult statusObtained = StyleClassController.RemoveStyle(styleClass.Id, style.Name);
                Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
            }
        }
    }
}

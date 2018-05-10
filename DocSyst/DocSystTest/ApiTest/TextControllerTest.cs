using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using DocSystWebApi.Controllers;
using DocSystWebApi.Models.DocumentStructureModels;
using DocSystWebApi.Models.UserModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class TextControllerTest
    {
        private TextModel textModel;
        private Text text;
        private User user;
        private UserModel userModel;
        private Mock<ITextBusinessLogic> mockTextBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockTextAuthorizationLogic;
        private TextController textController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            text = Utils.CreateTextForTest();
            textModel = TextModel.ToModel(text);
            mockTextAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockTextBusinessLogic = new Mock<ITextBusinessLogic>();
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            textController = new TextController(mockTextBusinessLogic.Object, mockTextAuthorizationLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", user.Token + "");
            mockTextAuthorizationLogic.Setup(b1 => b1.IsAValidToken(user.Token)).Returns(true);
            mockTextAuthorizationLogic.Setup(b1 => b1.IsAdmin(user.Token)).Returns(true);
            textController.Request = requestMessage;
        }

        [TestMethod]
        public void CreateTextController_WithParameters_Ok()
        {
            Assert.IsNotNull(textController);
        }

        [TestMethod]
        public void GetText_TextExists_Ok()
        {
            mockTextBusinessLogic.Setup(b1 => b1.GetText(text.Id)).Returns(text);
            IHttpActionResult statusObtained = textController.Get(text.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void GetText_BadRequest_Exception()
        {
            mockTextBusinessLogic.Setup(b1 => b1.GetText(text.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = textController.Get(text.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void AddText_ExpectedParameters_Ok()
        {
            mockTextBusinessLogic.Setup(b1 => b1.AddText(text));
            IHttpActionResult statusObtained = textController.Post(textModel);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void AddText_BadRequest_Exception()
        {
            mockTextBusinessLogic.Setup(b1 => b1.AddText(It.IsAny<Text>())).Throws(new Exception());
            IHttpActionResult statusObtained = textController.Post(textModel);
            Assert.IsNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void GetTexts_ExpectedParameters_Ok()
        {
            IList<Text> texts = new List<Text>();
            texts.Add(text);
            mockTextBusinessLogic.Setup(b1 => b1.GetTexts()).Returns(texts);
            IHttpActionResult statusObtained = textController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<TextModel>>);
        }

        [TestMethod]
        public void GetTexts_BadRequest_Exception()
        {
            IList<TextModel> textsModel = new List<TextModel>();
            textsModel.Add(textModel);
            mockTextBusinessLogic.Setup(b1 => b1.GetTexts()).Throws(new Exception());
            IHttpActionResult statusObtained = textController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<TextModel>>);
        }

        [TestMethod]
        public void ModifyText_ExpectedParameters_Ok()
        {
            mockTextBusinessLogic.Setup(b1 => b1.ModifyText(It.IsAny<Text>()));
            IHttpActionResult statusObtained = textController.Put(textModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyText_BadRequest_Exception()
        {
            IList<TextModel> textsModel = new List<TextModel>();
            textsModel.Add(textModel);
            mockTextBusinessLogic.Setup(b1 => b1.ModifyText(It.IsAny<Text>())).Throws(new Exception());
            IHttpActionResult statusObtained = textController.Put(textModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteText_ExpectedParameters_Ok()
        {
            mockTextBusinessLogic.Setup(b1 => b1.DeleteText(text.Id));
            IHttpActionResult statusObtained = textController.Delete(text.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteText_BadRequest_Exception()
        {
            mockTextBusinessLogic.Setup(b1 => b1.DeleteText(text.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = textController.Delete(text.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            var requestMessage = new HttpRequestMessage();
            ITextBusinessLogic textBL = new TextBusinessLogic(new TextDataAccess());
            IUserDataAccess userDa = new UserDataAccess();
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(userDa);
            TextController textC = new TextController(textBL, auth);
            textC.Request = requestMessage;
            TextModel text2 = TextModel.ToModel(Utils.CreateTextForTest());
            textC.Post(textModel);
            textC.Post(text2);
            text2.TextContent = "modified";
            textC.Put(text2);
            textC.Delete(textModel.Id);
            IHttpActionResult statusObtained = textC.Get();
        }
    }
}

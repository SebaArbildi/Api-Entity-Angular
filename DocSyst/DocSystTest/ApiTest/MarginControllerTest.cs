using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation;
using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
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

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class MarginControllerTest
    {
        private MarginModel marginModel;
        private Margin margin;
        private TextModel textModel;
        private Text text;
        private User user;
        private UserModel userModel;
        private Mock<IMarginBusinessLogic> mockMarginBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockMarginAuthorizationLogic;
        private Mock<IAuditLogBussinesLogic> mockAuditLogBusinessLogic;
        private MarginController marginController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            margin = Utils.CreateMarginForTest();
            marginModel = MarginModel.ToModel(margin);
            text = Utils.CreateTextForTest();
            textModel = TextModel.ToModel(text);
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            mockMarginAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockMarginBusinessLogic = new Mock<IMarginBusinessLogic>();
            mockAuditLogBusinessLogic = new Mock<IAuditLogBussinesLogic>();
            marginController = new MarginController(mockMarginBusinessLogic.Object, mockMarginAuthorizationLogic.Object, mockAuditLogBusinessLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", user.Token + "");
            requestMessage.Headers.Add("Username", "user1");
            mockMarginAuthorizationLogic.Setup(b1 => b1.IsAValidToken(user.Token)).Returns(true);
            mockMarginAuthorizationLogic.Setup(b1 => b1.IsAdmin(user.Token)).Returns(true);
            marginController.Request = requestMessage;
        }

        [TestMethod]
        public void CreateMarginController_WithParameters_Ok()
        {
            Assert.IsNotNull(marginController);
        }

        [TestMethod]
        public void GetMargin_MarginExists_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargin(margin.Id)).Returns(margin);
            IHttpActionResult statusObtained = marginController.Get(margin.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<MarginModel>);
        }

        [TestMethod]
        public void GetMargin_BadRequest_Exception()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargin(margin.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Get(margin.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<MarginModel>);
        }

        [TestMethod]
        public void AddMargin_ExpectedParameters_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.AddMargin(margin));
            IHttpActionResult statusObtained = marginController.Post(marginModel);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<MarginModel>);
        }

        [TestMethod]
        public void AddMargin_BadRequest_Exception()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.AddMargin(margin)).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Post(marginModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<MarginModel>);
        }

        [TestMethod]
        public void GetMargins_ExpectedParameters_Ok()
        {
            IList<Margin> margins = new List<Margin>();
            margins.Add(margin);
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargins()).Returns(margins);
            IHttpActionResult statusObtained = marginController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<MarginModel>>);
        }

        [TestMethod]
        public void GetMargins_BadRequest_Exception()
        {
            IList<MarginModel> marginsModel = new List<MarginModel>();
            marginsModel.Add(marginModel);
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargins()).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<MarginModel>>);
        }

        [TestMethod]
        public void ModifyMargin_ExpectedParameters_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.ModifyMargin(It.IsAny<Margin>()));
            IHttpActionResult statusObtained = marginController.Put(Guid.NewGuid(),marginModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyMargin_BadRequest_Exception()
        {
            IList<MarginModel> marginsModel = new List<MarginModel>();
            marginsModel.Add(marginModel);
            mockMarginBusinessLogic.Setup(b1 => b1.ModifyMargin(It.IsAny<Margin>())).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Put(Guid.NewGuid(),marginModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteMargin_ExpectedParameters_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.DeleteMargin(It.IsAny<Guid>()));
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargin(margin.Id)).Returns(new Margin()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = marginController.Delete(margin.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteMargin_BadRequest_Exception()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.DeleteMargin(margin.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Delete(margin.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<MarginModel>);
        }

        [TestMethod]
        public void PostTextMargin_ExpectedParameters_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.SetText(margin.Id, text));
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargin(margin.Id)).Returns(new Margin()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = marginController.Put(margin.Id,TextModel.ToModel(text));
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void PostTextMargin_BadRequest_Exception()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.SetText(margin.Id, text)).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Put(margin.Id, TextModel.ToModel(text));
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void ClearTextsMargin_ExpectedParameters_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.ClearText(margin.Id));
            mockMarginBusinessLogic.Setup(b1 => b1.GetMargin(margin.Id)).Returns(new Margin()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = marginController.Put(margin.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ClearTextsMargin_BadRequest_Ok()
        {
            mockMarginBusinessLogic.Setup(b1 => b1.ClearText(margin.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = marginController.Put(margin.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            var requestMessage = new HttpRequestMessage();
            IMarginBusinessLogic marginBL = new MarginBusinessLogic(new MarginDataAccess());
            IUserDataAccess userDa = new UserDataAccess();
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(userDa);
            IAuditLogBussinesLogic audit = new AuditLogBussinesLogic();
            MarginController marginC = new MarginController(marginBL, auth, audit);
            marginC.Request = requestMessage;
            MarginModel margin2 = MarginModel.ToModel(Utils.CreateMarginForTest());
            marginC.Post(marginModel);
            marginC.Post(margin2);
            marginC.Get(margin.Id);
            margin2.OwnStyleClass = "modified";
            marginC.Put(margin2.Id,margin2);
            marginC.Delete(marginModel.Id);
            IHttpActionResult statusObtained = marginC.Get();
        }
    }
}

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
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DocSystTest.ApiTest
{
    [TestClass]
    public class ParagraphControllerTest
    {
        private ParagraphModel paragraphModel;
        private Paragraph paragraph;
        private TextModel textModel;
        private Text text;
        private User user;
        private UserModel userModel;
        private Mock<IParagraphBusinessLogic> mockParagraphBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockParagraphAuthorizationLogic;
        private Mock<IAuditLogBussinesLogic> mockAuditLogBusinessLogic;
        private ParagraphController paragraphController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            paragraph = Utils.CreateParagraphForTest();
            paragraphModel = ParagraphModel.ToModel(paragraph);
            text = Utils.CreateTextForTest();
            textModel = TextModel.ToModel(text);
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            mockParagraphAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockParagraphBusinessLogic = new Mock<IParagraphBusinessLogic>();
            mockAuditLogBusinessLogic = new Mock<IAuditLogBussinesLogic>();
            paragraphController = new ParagraphController(mockParagraphBusinessLogic.Object, mockParagraphAuthorizationLogic.Object, mockAuditLogBusinessLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", user.Token + "");
            requestMessage.Headers.Add("Username", "user1");
            mockParagraphAuthorizationLogic.Setup(b1 => b1.IsAValidToken(user.Token)).Returns(true);
            mockParagraphAuthorizationLogic.Setup(b1 => b1.IsAdmin(user.Token)).Returns(true);
            paragraphController.Request = requestMessage;
        }

        [TestMethod]
        public void CreateParagraphController_WithParameters_Ok()
        {
            Assert.IsNotNull(paragraphController);
        }

        [TestMethod]
        public void GetParagraph_ParagraphExists_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(paragraph);
            IHttpActionResult statusObtained = paragraphController.Get(paragraph.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<ParagraphModel>);
        }

        [TestMethod]
        public void GetParagraph_BadRequest_Exception()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Get(paragraph.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<ParagraphModel>);
        }

        [TestMethod]
        public void AddParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.AddParagraph(paragraph));
            IHttpActionResult statusObtained = paragraphController.Post(paragraphModel);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<ParagraphModel>);
        }

        [TestMethod]
        public void AddParagraph_BadRequest_Exception()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.AddParagraph(paragraph)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Post(paragraphModel);
            Assert.IsNull(statusObtained as CreatedAtRouteNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetParagraphs_ExpectedParameters_Ok()
        {
            IList<Paragraph> paragraphs = new List<Paragraph>();
            paragraphs.Add(paragraph);
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraphs()).Returns(paragraphs);
            IHttpActionResult statusObtained = paragraphController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<ParagraphModel>>);
        }

        [TestMethod]
        public void GetParagraphs_BadRequest_Exception()
        {
            IList<ParagraphModel> paragraphsModel = new List<ParagraphModel>();
            paragraphsModel.Add(paragraphModel);
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraphs()).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<ParagraphModel>>);
        }

        [TestMethod]
        public void ModifyParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.ModifyParagraph(It.IsAny<Paragraph>()));
            IHttpActionResult statusObtained = paragraphController.Put(paragraphModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyParagraph_BadRequest_Exception()
        {
            IList<ParagraphModel> paragraphsModel = new List<ParagraphModel>();
            paragraphsModel.Add(paragraphModel);
            mockParagraphBusinessLogic.Setup(b1 => b1.ModifyParagraph(It.IsAny<Paragraph>())).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Put(paragraphModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.DeleteParagraph((It.IsAny<Guid>())));
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(new Paragraph()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = paragraphController.Delete(paragraph.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteParagraph_BadRequest_Exception()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.DeleteParagraph(paragraph.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Delete(paragraph.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ClearTextsParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.ClearText(paragraph.Id));
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(new Paragraph()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = paragraphController.Put(paragraph.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ClearTextsParagraph_BadRequest_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.ClearText(paragraph.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Put(paragraph.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetTextParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.GetTextAt(paragraph.Id,0)).Returns(text);
            IHttpActionResult statusObtained = paragraphController.Get(paragraph.Id,0);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void GetTextParagraph_BadRequest_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.GetTextAt(paragraph.Id, 0)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Get(paragraph.Id,0);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void PostTextAtLastParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.PutTextAtLast(paragraph.Id, text));
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(new Paragraph()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = paragraphController.Post(paragraph.Id, textModel);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void PostTextAtLastParagraph_BadRequest_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.PutTextAtLast(paragraph.Id, It.IsAny<Text>())).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Post(paragraph.Id, textModel);
            Assert.IsNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void PostTextAtParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.PutTextAt(paragraph.Id, text, 0));
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(new Paragraph()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = paragraphController.Post(paragraph.Id, textModel, 0);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void PostTextAtParagraph_BadRequest_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.PutTextAt(paragraph.Id, It.IsAny<Text>(), 0)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Post(paragraph.Id, textModel, 0);
            Assert.IsNull(statusObtained as CreatedAtRouteNegotiatedContentResult<TextModel>);
        }

        [TestMethod]
        public void MoveTextToParagraph_ExpectedParameters_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.MoveTextTo(paragraph.Id, text.Id, 0));
            mockParagraphBusinessLogic.Setup(b1 => b1.GetParagraph(paragraph.Id)).Returns(new Paragraph()
            {
                DocumentId = Guid.NewGuid()
            });
            IHttpActionResult statusObtained = paragraphController.Put(paragraph.Id, text.Id, 0);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void MoveTextToParagraph_BadRequest_Ok()
        {
            mockParagraphBusinessLogic.Setup(b1 => b1.MoveTextTo(paragraph.Id, text.Id, 0)).Throws(new Exception());
            IHttpActionResult statusObtained = paragraphController.Put(paragraph.Id, text.Id, 0);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            var requestMessage = new HttpRequestMessage();
            IParagraphBusinessLogic paragraphBL = new ParagraphBusinessLogic(new ParagraphDataAccess());
            IUserDataAccess userDa = new UserDataAccess();
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(userDa);
            IAuditLogBussinesLogic audit = new AuditLogBussinesLogic();
            ParagraphController paragraphC = new ParagraphController(paragraphBL, auth, audit);
            paragraphC.Request = requestMessage;
            ParagraphModel paragraph2 = ParagraphModel.ToModel(Utils.CreateParagraphForTest());
            paragraphC.Post(paragraphModel);
            paragraphC.Post(paragraph2);
            paragraphC.Get(paragraph.Id);
            paragraph2.OwnStyleClass = "modified";
            paragraphC.Put(paragraph2);
            paragraphC.Delete(paragraphModel.Id);
            IHttpActionResult statusObtained = paragraphC.Get();
        }
    }
}

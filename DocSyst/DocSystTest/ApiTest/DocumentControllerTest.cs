using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
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
    public class DocumentControllerTest
    {
        private DocumentModel documentModel;
        private Document document;
        private ParagraphModel paragraphModel;
        private Paragraph paragraph;
        private MarginModel marginModel;
        private Margin margin;
        private User user;
        private UserModel userModel;
        private Mock<IDocumentBusinessLogic> mockDocumentBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockDocumentAuthorizationLogic;
        private Mock<IAuditLogBussinesLogic> mockAuditLogBusinessLogic;
        private DocumentController documentController;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            document = Utils.CreateDocumentForTest();
            documentModel = DocumentModel.ToModel(document);
            paragraph = Utils.CreateParagraphForTest();
            paragraphModel = ParagraphModel.ToModel(paragraph);
            margin = Utils.CreateMarginForTest();
            marginModel = MarginModel.ToModel(margin);
            user = Utils.CreateUserForTest();
            userModel = UserModel.ToModel(user);
            mockDocumentAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockDocumentBusinessLogic = new Mock<IDocumentBusinessLogic>();
            mockAuditLogBusinessLogic = new Mock<IAuditLogBussinesLogic>();
            documentController = new DocumentController(mockDocumentBusinessLogic.Object, mockDocumentAuthorizationLogic.Object, mockAuditLogBusinessLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", user.Token + "");
            requestMessage.Headers.Add("Username", "user1");
            mockDocumentAuthorizationLogic.Setup(b1 => b1.IsAValidToken(user.Token)).Returns(true);
            mockDocumentAuthorizationLogic.Setup(b1 => b1.IsAdmin(user.Token)).Returns(true);
            documentController.Request = requestMessage;
        }

        [TestMethod]
        public void CreateDocumentController_WithParameters_Ok()
        {
            Assert.IsNotNull(documentController);
        }

        [TestMethod]
        public void GetDocument_DocumentExists_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocument(document.Id)).Returns(document);
            IHttpActionResult statusObtained = documentController.Get(document.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<DocumentModel>);
        }

        [TestMethod]
        public void GetDocument_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocument(document.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Get(document.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<DocumentModel>);
        }

        [TestMethod]
        public void AddDocument_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.AddDocument(document));
            IHttpActionResult statusObtained = documentController.Post(documentModel);
            Assert.IsNotNull(statusObtained as CreatedAtRouteNegotiatedContentResult<DocumentModel>);
        }

        [TestMethod]
        public void AddDocument_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.AddDocument(document)).Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Post(documentModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetDocuments_ExpectedParameters_Ok()
        {
            IList<Document> documents = new List<Document>
            {
                document
            };
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocuments(user.Token.ToString())).Returns(documents);
            IHttpActionResult statusObtained = documentController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<DocumentModel>>);
        }

        [TestMethod]
        public void GetDocuments_BadRequest_Exception()
        {
            IList<DocumentModel> documentsModel = new List<DocumentModel>
            {
                documentModel
            };
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocuments()).Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<DocumentModel>>);
        }

        [TestMethod]
        public void ModifyDocument_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.ModifyDocument(document));
            IHttpActionResult statusObtained = documentController.Put(documentModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifyDocument_BadRequest_Exception()
        {
            IList<DocumentModel> documentsModel = new List<DocumentModel>
            {
                documentModel
            };
            mockDocumentBusinessLogic.Setup(b1 => b1.ModifyDocument(document)).Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Put(documentModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<DocumentModel>);
        }

        [TestMethod]
        public void DeleteDocument_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.DeleteDocument(document.Id));
            IHttpActionResult statusObtained = documentController.Delete(document.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteDocument_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.DeleteDocument(document.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Delete(document.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetDocumentPartParagraph_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentParagraph(document.Id,0))
                .Returns(paragraph);
            IHttpActionResult statusObtained = documentController.Get(document.Id,0);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<ParagraphModel>);
        }

        [TestMethod]
        public void GetDocumentPartParagraph_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentParagraph(document.Id, 0))
                .Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Get(document.Id, 0);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<ParagraphModel>);
        }

        [TestMethod]
        public void GetDocumentPartFooter_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentMargin(document.Id, MarginAlign.FOOTER))
                .Returns(margin);
            IHttpActionResult statusObtained = documentController.Get(document.Id, MarginAlign.FOOTER);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<BodyModel>);
        }

        [TestMethod]
        public void GetDocumentPartFooter_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentMargin(document.Id, MarginAlign.FOOTER))
                .Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Get(document.Id, MarginAlign.FOOTER);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<BodyModel>);
        }

        [TestMethod]
        public void GetDocumentPartHeader_ExpectedParameters_Ok()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentMargin(document.Id, MarginAlign.HEADER))
                .Returns(margin);
            IHttpActionResult statusObtained = documentController.Get(document.Id, MarginAlign.HEADER);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<BodyModel>);
        }

        [TestMethod]
        public void GetDocumentPartHeader_BadRequest_Exception()
        {
            mockDocumentBusinessLogic.Setup(b1 => b1.GetDocumentMargin(document.Id, MarginAlign.HEADER))
                .Throws(new Exception());
            IHttpActionResult statusObtained = documentController.Get(document.Id, MarginAlign.HEADER);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<BodyModel>);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            var requestMessage = new HttpRequestMessage();
            IUserDataAccess userDa = new UserDataAccess();
            IDocumentBusinessLogic documentBL = new DocumentBusinessLogic(new DocumentDataAccess(),userDa);
            IAuthorizationBusinessLogic auth = new AuthorizationBusinessLogic(userDa);
            IAuditLogBussinesLogic audit = new AuditLogBussinesLogic();
            DocumentController documentC = new DocumentController(documentBL, auth, audit)
            {
                Request = requestMessage
            };
            DocumentModel document2 = DocumentModel.ToModel(Utils.CreateDocumentForTest());
            documentC.Post(documentModel);
            documentC.Post(document2);
            documentC.Get(document.Id);
            document2.OwnStyleClass = "modified";
            documentC.Put(document2);
            documentC.Delete(documentModel.Id);
            IHttpActionResult statusObtained = documentC.Get();
        }
    }
}

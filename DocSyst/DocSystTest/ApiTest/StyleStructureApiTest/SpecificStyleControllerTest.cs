using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystWebApi.Models.StyleStructureModels;
using DocSystEntities.StyleStructure;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using Moq;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using DocSystWebApi.Controllers;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccess;

namespace DocSystTest.ApiTest.StyleStructureApiTest
{
    [TestClass]
    public class SpecificStyleControllerTest
    {
        private SpecificStyleModel specificStyleModel;
        private SpecificStyle specificStyle;
        private Mock<ISpecificStyleBusinessLogic> mockSpecificStyleBusinessLogic;
        private Mock<IAuthorizationBusinessLogic> mockUserAuthorizationLogic;
        private SpecificStyleController specificStyleController;


        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            specificStyle = Utils.CreateSpecificStyleForTest("specific style");
            specificStyleModel = SpecificStyleModel.ToModel(specificStyle);
            mockUserAuthorizationLogic = new Mock<IAuthorizationBusinessLogic>();
            mockSpecificStyleBusinessLogic = new Mock<ISpecificStyleBusinessLogic>();
            specificStyleController = new SpecificStyleController(mockSpecificStyleBusinessLogic.Object, mockUserAuthorizationLogic.Object);
            InitializeToken();
        }

        private void InitializeToken()
        {
            Guid token = Guid.NewGuid();
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", token + "");
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(token)).Returns(true);
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(token)).Returns(true);
            specificStyleController.Request = requestMessage;
        }

        [TestMethod]
        public void GetSpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Get(specificStyle.Id)).Returns(specificStyle);
            IHttpActionResult statusObtained = specificStyleController.Get(specificStyle.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<SpecificStyleModel>);
        }

        [TestMethod]
        public void GetSpecificStyle_BadRequest_Exception()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Get(specificStyle.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = specificStyleController.Get(specificStyle.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<SpecificStyleModel>);
        }

        [TestMethod]
        public void AddSpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Add(specificStyle));
            IHttpActionResult statusObtained = specificStyleController.Post(specificStyleModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void AddSpecificStyle_BadRequest_Exception()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Add(specificStyle)).Throws(new Exception());
            IHttpActionResult statusObtained = specificStyleController.Post(specificStyleModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void GetSpecificStyles_ExpectedParameters_Ok()
        {
            IList<SpecificStyle> specificStyles = new List<SpecificStyle>();
            specificStyles.Add(specificStyle);
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Get()).Returns(specificStyles);
            IHttpActionResult statusObtained = specificStyleController.Get();
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<IList<SpecificStyleModel>>);
        }

        [TestMethod]
        public void GetSpecificStyles_BadRequest_Exception()
        {
            IList<SpecificStyle> specificStyles = new List<SpecificStyle>();
            specificStyles.Add(specificStyle);
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Get()).Throws(new Exception());
            IHttpActionResult statusObtained = specificStyleController.Get();
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<IList<SpecificStyleModel>>);
        }

        [TestMethod]
        public void ModifySpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Modify(specificStyle));
            IHttpActionResult statusObtained = specificStyleController.Put(specificStyleModel.Id, specificStyleModel);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void ModifySpecificStyle_BadRequest_Exception()
        {
            IList<SpecificStyleModel> specificStylesModel = new List<SpecificStyleModel>();
            specificStylesModel.Add(specificStyleModel);
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Modify(specificStyle)).Throws(new Exception());
            IHttpActionResult statusObtained = specificStyleController.Put(specificStyleModel.Id, specificStyleModel);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteSpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Delete(specificStyle.Id));
            IHttpActionResult statusObtained = specificStyleController.Delete(specificStyle.Id);
            Assert.IsNotNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void DeleteSpecificStyle_BadRequest_Exception()
        {
            mockSpecificStyleBusinessLogic.Setup(b1 => b1.Delete(specificStyle.Id)).Throws(new Exception());
            IHttpActionResult statusObtained = specificStyleController.Delete(specificStyle.Id);
            Assert.IsNull(statusObtained as OkNegotiatedContentResult<string>);
        }

        [TestMethod]
        public void IntegrationTest()
        {
            Guid token = Guid.NewGuid();
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Token", token + "");
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAValidToken(token)).Returns(true);
            mockUserAuthorizationLogic.Setup(b1 => b1.IsAdmin(token)).Returns(true);

            ISpecificStyleDataAccess specificStyleDA = new SpecificStyleDataAccess();
            ISpecificStyleBusinessLogic specificStyleBL = new SpecificStyleBusinessLogic(specificStyleDA);
            SpecificStyleController specificStyleController = new SpecificStyleController(specificStyleBL, mockUserAuthorizationLogic.Object);
            specificStyleController.Request = requestMessage;

            SpecificStyle specificStyle2 = Utils.CreateSpecificStyleForTest("specifi");
            specificStyleController.Post(SpecificStyleModel.ToModel(specificStyle2));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using Moq;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccess;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using System.Collections.Generic;

namespace DocSystTest.BusinessLogicTest.StyleStructureBusinessLogicTest
{
    [TestClass]
    public class SpecificStyleBusinessLogicTest
    {
        private Mock<ISpecificStyleDataAccess> mockSpecificStyleDataAccess;
        private ISpecificStyleBusinessLogic specificStyleBusinessLogic;
        private SpecificStyle specificStyle;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockSpecificStyleDataAccess = new Mock<ISpecificStyleDataAccess>();
            specificStyleBusinessLogic = new SpecificStyleBusinessLogic(mockSpecificStyleDataAccess.Object);
            specificStyle = Utils.CreateSpecificStyleForTest("specificStyle1");
        }

        [TestMethod]
        public void CreateSpecificStyleBL_WithoutParameters_Ok()
        {
            ISpecificStyleBusinessLogic specificStyleBL = new SpecificStyleBusinessLogic();

            Assert.IsNotNull(specificStyleBL);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            ISpecificStyleDataAccess specificStyleDataAccess = new SpecificStyleDataAccess();

            ISpecificStyleBusinessLogic specificStyleBL = new SpecificStyleBusinessLogic(specificStyleDataAccess);

            Assert.IsNotNull(specificStyleBL);
        }

        [TestMethod]
        public void AddSpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Add(specificStyle));
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(false);
            specificStyleBusinessLogic.Add(specificStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddSpecificStyle_SpecificStyleHasNullFields_ArgumentNullException()
        {
            specificStyle.Name = null;

            specificStyleBusinessLogic.Add(specificStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddSpecificStyle_SpecificStyleAlreadyExists_DuplicateException()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(true);

            specificStyleBusinessLogic.Add(specificStyle);
        }

        [TestMethod]
        public void DeleteSpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Delete(specificStyle.Id));
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(true);
            specificStyleBusinessLogic.Delete(specificStyle.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteSpecificStyle_SpecificStyleDontExists_ArgumentNullException()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(false);
            specificStyleBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifySpecificStyle_ExpectedParameters_Ok()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Modify(specificStyle));
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(true);
            specificStyleBusinessLogic.Modify(specificStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifySpecificStyle_SpecificStyleHasNullFields_ArgumentNullException()
        {
            specificStyle.Implementation = null;
            specificStyleBusinessLogic.Modify(specificStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifySpecificStyle_SpecificStyleNotExists_DuplicateException()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Exists(specificStyle.Id)).Returns(false);
            specificStyleBusinessLogic.Modify(specificStyle);
        }

        [TestMethod]
        public void GetSpecificStyles_ExpectedParameters_Ok()
        {

            mockSpecificStyleDataAccess.Setup(b1 => b1.Get()).Returns(new List<SpecificStyle>());
            IList<SpecificStyle> specificsStyles = specificStyleBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSpecificStyles_PersistenceException_ArgumentException()
        {
            mockSpecificStyleDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<SpecificStyle> specificsStyles = specificStyleBusinessLogic.Get();
        }
    }
}

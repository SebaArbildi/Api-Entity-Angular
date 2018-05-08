using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using Moq;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccess;

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
    }
}

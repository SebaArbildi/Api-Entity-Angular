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
            specificStyleBusinessLogic.Add(specificStyle);
            SpecificStyle obtained = specificStyleBusinessLogic.Get(specificStyle.Id);
            Assert.AreEqual(specificStyle, obtained);
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
            specificStyleBusinessLogic.Add(specificStyle);
            specificStyleBusinessLogic.Delete(specificStyle.Id);
            bool obtained = specificStyleBusinessLogic.Exists(specificStyle.Id);
            Assert.IsFalse(obtained);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteSpecificStyle_SpecificStyleDontExists_ArgumentNullException()
        {
            specificStyleBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifySpecificStyle_ExpectedParameters_Ok()
        {
            specificStyleBusinessLogic.Add(specificStyle);
            specificStyle.Implementation = "asdasd";
            specificStyleBusinessLogic.Modify(specificStyle);
            SpecificStyle obtained = specificStyleBusinessLogic.Get(specificStyle.Id);
            Assert.AreEqual(specificStyle.Implementation, obtained.Implementation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifySpecificStyle_SpecificStyleHasNullFields_ArgumentNullException()
        {
            specificStyleBusinessLogic.Add(specificStyle);
            specificStyle.Implementation = null;
            specificStyleBusinessLogic.Modify(specificStyle);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void ModifySpecificStyle_SpecificStyleNotExists_DuplicateException()
        {
            specificStyleBusinessLogic.Modify(specificStyle);
        }

        [TestMethod]
        public void GetSpecificStyles_ExpectedParameters_Ok()
        {
            specificStyleBusinessLogic.Add(specificStyle);
            IList<SpecificStyle> specificsStyles = specificStyleBusinessLogic.Get();
            Assert.IsTrue(specificsStyles.Contains(specificStyle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSpecificStyles_PersistenceException_ArgumentException()
        {
            specificStyleBusinessLogic.Add(specificStyle);
            IList<SpecificStyle> specificsStyles = specificStyleBusinessLogic.Get();
        }


    }
}

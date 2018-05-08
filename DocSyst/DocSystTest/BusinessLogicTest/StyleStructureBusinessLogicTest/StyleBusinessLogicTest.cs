using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.StyleStructure;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;
using System.Collections.Generic;

namespace DocSystTest.BusinessLogicTest.StyleStructureBusinessLogicTest
{
    [TestClass]
    public class StyleBusinessLogicTest
    {
        private Mock<IStyleDataAccess> mockStyleDataAccess;
        private IStyleBusinessLogic styleBusinessLogic;
        private Style style;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockStyleDataAccess = new Mock<IStyleDataAccess>();
            styleBusinessLogic = new StyleBusinessLogic(mockStyleDataAccess.Object);
            style = Utils.CreateStyleForTest();
        }

        [TestMethod]
        public void CreateStyleBL_WithoutParameters_Ok()
        {
            IStyleBusinessLogic StyleBL = new StyleBusinessLogic();

            Assert.IsNotNull(StyleBL);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            IStyleDataAccess styleDataAccess = new StyleDataAccess();

            IStyleBusinessLogic styleBL = new StyleBusinessLogic(styleDataAccess);

            Assert.IsNotNull(styleBL);
        }

        [TestMethod]
        public void AddStyle_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Add(style));
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(false);
            styleBusinessLogic.Add(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStyle_StyleHasNullFields_ArgumentNullException()
        {
            style.Name = null;

            styleBusinessLogic.Add(style);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddStyle_StyleAlreadyExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(true);

            styleBusinessLogic.Add(style);
        }

        [TestMethod]
        public void DeleteStyle_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Delete(style.Name));
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            styleBusinessLogic.Delete(style.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteStyle_StyleDontExists_ArgumentNullException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(false);
            styleBusinessLogic.Delete("asdasd");
        }

        [TestMethod]
        public void ModifyStyle_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Modify(style));
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            styleBusinessLogic.Modify(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyStyle_StyleHasNullFields_ArgumentNullException()
        {
            style.Implementation = null;
            styleBusinessLogic.Modify(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyStyle_StyleNotExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Name)).Returns(false);
            styleBusinessLogic.Modify(style);
        }

        [TestMethod]
        public void GetStyles_ExpectedParameters_Ok()
        {

            mockStyleDataAccess.Setup(b1 => b1.Get()).Returns(new List<Style>());
            IList<Style> specificsStyles = styleBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStyles_PersistenceException_ArgumentException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<Style> specificsStyles = styleBusinessLogic.Get();
        }

        [TestMethod]
        public void GetStyle_ExpectedParameters_Ok()
        {

            mockStyleDataAccess.Setup(b1 => b1.Get(style.Name)).Returns(style);
            Style obtained = styleBusinessLogic.Get(style.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStyle_PersistenceException_ArgumentException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<Style> specificsStyles = styleBusinessLogic.Get();
        }
    }
}

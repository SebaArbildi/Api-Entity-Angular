using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.StyleStructure;

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
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(false);
            StyleBusinessLogic.Add(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStyle_StyleHasNullFields_ArgumentNullException()
        {
            style.Name = null;

            StyleBusinessLogic.Add(style);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddStyle_StyleAlreadyExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(true);

            StyleBusinessLogic.Add(style);
        }

        [TestMethod]
        public void DeleteStyle_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Delete(style.Id));
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(true);
            StyleBusinessLogic.Delete(style.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteStyle_StyleDontExists_ArgumentNullException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(false);
            StyleBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifyStyle_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Modify(style));
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(true);
            StyleBusinessLogic.Modify(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyStyle_StyleHasNullFields_ArgumentNullException()
        {
            style.Implementation = null;
            StyleBusinessLogic.Modify(style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyStyle_StyleNotExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(style.Id)).Returns(false);
            StyleBusinessLogic.Modify(style);
        }

        [TestMethod]
        public void GetStyles_ExpectedParameters_Ok()
        {

            mockStyleDataAccess.Setup(b1 => b1.Get()).Returns(new List<style>());
            IList<style> specificsStyles = StyleBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStyles_PersistenceException_ArgumentException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<style> specificsStyles = StyleBusinessLogic.Get();
        }
    }
}

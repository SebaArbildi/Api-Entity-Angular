using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.StyleStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystTest.BusinessLogicTest.StyleStructureBusinessLogicTest
{
    [TestClass]
    public class StyleClassBusinessLogicTest
    {
        private Mock<IStyleClassDataAccess> mockStyleDataAccess;
        private IStyleClassBusinessLogic styleClassBusinessLogic;
        private StyleClass styleClass;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockStyleDataAccess = new Mock<IStyleClassDataAccess>();
            styleClassBusinessLogic = new StyleClassBusinessLogic(mockStyleDataAccess.Object);
            styleClass = Utils.CreateStyleClassForTest();
        }

        [TestMethod]
        public void CreateSpecificStyleBL_WithoutParameters_Ok()
        {
            IStyleClassBusinessLogic styleClassBL = new StyleClassBusinessLogic();

            Assert.IsNotNull(styleClassBL);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            IStyleClassDataAccess styleClassDataAccess = new StyleClassDataAccess();

            IStyleClassBusinessLogic styleClassBL = new SpecificStyleBusinessLogic(styleClassDataAccess);

            Assert.IsNotNull(styleClassBL);
        }

        [TestMethod]
        public void AddStyleClass_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Add(styleClass));
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            styleClassBusinessLogic.Add(styleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStyleClass_StyleClassHasNullFields_ArgumentNullException()
        {
            styleClass.Name = null;

            styleClassBusinessLogic.Add(styleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddStyleClass_StyleClassAlreadyExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);

            styleClassBusinessLogic.Add(styleClass);
        }

        [TestMethod]
        public void DeleteStyleClass_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Delete(styleClass.Id));
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            styleClassBusinessLogic.Delete(styleClass.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteStyleClasse_StyleClassDontExists_ArgumentNullException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            styleClassBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifyStyleClass_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Modify(styleClass));
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            styleClassBusinessLogic.Modify(styleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyStyleClass_StyleClassHasNullFields_ArgumentNullException()
        {
            styleClass.Name = null;
            styleClassBusinessLogic.Modify(styleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyStyleClasses_StyleClassNotExists_DuplicateException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            styleClassBusinessLogic.Modify(styleClass);
        }

        [TestMethod]
        public void GetStyleClasses_ExpectedParameters_Ok()
        {

            mockStyleDataAccess.Setup(b1 => b1.Get()).Returns(new List<StyleClass>());
            IList<StyleClass> styleClasses = styleClassBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStyleClasses_PersistenceException_ArgumentException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<StyleClass> specificsStyles = styleClassBusinessLogic.Get();
        }

        [TestMethod]
        public void GetStyleClass_ExpectedParameters_Ok()
        {
            mockStyleDataAccess.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
            styleClassBusinessLogic.Get(styleClass.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStyleClass_ExpectedParameters_ArgumentNullException()
        {
            mockStyleDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Throws(new ArgumentNullException());
            styleClassBusinessLogic.Get(styleClass.Id);
        }

    }
}

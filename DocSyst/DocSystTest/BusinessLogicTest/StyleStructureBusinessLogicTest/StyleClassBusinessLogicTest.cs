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
        private Mock<IStyleClassDataAccess> mockStyleClassDataAccess;
        private Mock<IStyleBusinessLogic> mockStyleBusinessLogic;
        private IStyleClassBusinessLogic styleClassBusinessLogic;
        private StyleClass styleClass;
        private Style style;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockStyleBusinessLogic = new Mock<IStyleBusinessLogic>();
            mockStyleClassDataAccess = new Mock<IStyleClassDataAccess>();
            styleClassBusinessLogic = new StyleClassBusinessLogic(mockStyleClassDataAccess.Object, mockStyleBusinessLogic.Object);
            styleClass = Utils.CreateStyleClassForTest();
            style = Utils.CreateStyleForTest();
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

            IStyleClassBusinessLogic styleClassBL = new StyleClassBusinessLogic(styleClassDataAccess, mockStyleBusinessLogic.Object);

            Assert.IsNotNull(styleClassBL);
        }

        [TestMethod]
        public void AddStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Add(styleClass));
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
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
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);

            styleClassBusinessLogic.Add(styleClass);
        }

        [TestMethod]
        public void DeleteStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Delete(styleClass.Id));
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            styleClassBusinessLogic.Delete(styleClass.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteStyleClasse_StyleClassDontExists_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            styleClassBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifyStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Modify(styleClass));
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
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
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            styleClassBusinessLogic.Modify(styleClass);
        }

        [TestMethod]
        public void GetStyleClasses_ExpectedParameters_Ok()
        {

            mockStyleClassDataAccess.Setup(b1 => b1.Get()).Returns(new List<StyleClass>());
            IList<StyleClass> styleClasses = styleClassBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStyleClasses_PersistenceException_ArgumentException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<StyleClass> specificsStyles = styleClassBusinessLogic.Get();
        }

        [TestMethod]
        public void GetStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleClassDataAccess.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
            styleClassBusinessLogic.Get(styleClass.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStyleClass_ExpectedParameters_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Throws(new ArgumentNullException());
            styleClassBusinessLogic.Get(styleClass.Id);
        }

        [TestMethod]
        public void AddStyleToStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            mockStyleClassDataAccess.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
            mockStyleClassDataAccess.Setup(b1 => b1.Modify(styleClass));
            styleClassBusinessLogic.AddStyle(styleClass.Id, style);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStyleToStyleClass_StyleDontExists_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(false);
            styleClassBusinessLogic.AddStyle(styleClass.Id, style);
        }

        [ExpectedException(typeof(ArgumentException))]
        public void AddStyleToStyleClass_StyleClassDontExists_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            styleClassBusinessLogic.AddStyle(styleClass.Id, style);
        }

        [TestMethod]
        public void RemoveStyleFromStyleClass_ExpectedParameters_Ok()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            mockStyleBusinessLogic.Setup(b1 => b1.Get(style.Name)).Returns(style);
            mockStyleClassDataAccess.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
            mockStyleClassDataAccess.Setup(b1 => b1.Modify(styleClass));
            styleClassBusinessLogic.RemoveStyle(styleClass.Id, style.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStyleFromStyleClass_StyleDontExists_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(false);
            styleClassBusinessLogic.RemoveStyle(styleClass.Id, style.Name);
        }

        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStyleFromStyleClass_StyleClassDontExists_ArgumentNullException()
        {
            mockStyleClassDataAccess.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            mockStyleBusinessLogic.Setup(b1 => b1.Exists(style.Name)).Returns(true);
            styleClassBusinessLogic.RemoveStyle(styleClass.Id, style.Name);
        }

    }
}

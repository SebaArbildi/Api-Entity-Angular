using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using Moq;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;

namespace DocSystTest.BusinessLogicTest.StyleStructureBusinessLogicTest
{
    [TestClass]
    public class FormatBusinessLogicTest
    {
        private Mock<IFormatDataAccess> mockFormatDataAccess;
        private Mock<IStyleClassBusinessLogic> mockStyleClassBusinessLogic;
        private IFormatBusinessLogic formatBusinessLogic;
        private StyleClass styleClass;
        private Format format;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockFormatDataAccess = new Mock<IFormatDataAccess>();
            formatBusinessLogic = new FormatBusinessLogic(mockFormatDataAccess.Object, mockStyleClassBusinessLogic.Object);
            styleClass = Utils.CreateStyleClassForTest();
            format = Utils.CreateFormatForTest();
        }

        [TestMethod]
        public void AddFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Add(format));
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(false);
            formatBusinessLogic.Add(format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddFormat_FormatHasNullFields_ArgumentNullException()
        {
            format.Name = null;

            formatBusinessLogic.Add(format);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddFormat_FormatAlreadyExists_DuplicateException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);

            formatBusinessLogic.Add(format);
        }

        [TestMethod]
        public void DeleteFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Delete(format.Id));
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            formatBusinessLogic.Delete(format.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteFormat_FormatDontExists_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(false);
            formatBusinessLogic.Delete(Guid.NewGuid());
        }

        [TestMethod]
        public void ModifyFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Modify(format));
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            formatBusinessLogic.Modify(format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyFormat_FormatHasNullFields_ArgumentNullException()
        {
            format.Name = null;
            formatBusinessLogic.Modify(format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyFormat_FormatNotExists_DuplicateException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(false);
            formatBusinessLogic.Modify(format);
        }

        [TestMethod]
        public void GetFormats_ExpectedParameters_Ok()
        {

            mockFormatDataAccess.Setup(b1 => b1.Get()).Returns(new List<Format>());
            IList<Format> formats = formatBusinessLogic.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFormats_PersistenceException_ArgumentException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Get()).Throws(new ArgumentException());
            IList<Format> formats = formatBusinessLogic.Get();
        }

        [TestMethod]
        public void GetFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            mockFormatDataAccess.Setup(b1 => b1.Get(format.Id)).Returns(format);
            formatBusinessLogic.Get(format.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFormat_ExpectedParameters_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Throws(new ArgumentNullException());
            formatBusinessLogic.Get(format.Id);
        }

        [TestMethod]
        public void AddStyleClassToFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockFormatDataAccess.Setup(b1 => b1.Get(format.Id)).Returns(format);
            mockFormatDataAccess.Setup(b1 => b1.Modify(format));
            formatBusinessLogic.AddStyle(format.Id, styleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSStyleClassToFormat_StyleClassDontExists_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            formatBusinessLogic.AddStyle(format.Id, styleClass);
        }

        [ExpectedException(typeof(ArgumentException))]
        public void AddStyleClassToFormat_FormatDontExists_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(false);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            formatBusinessLogic.AddStyle(format.Id, styleClass);
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_ExpectedParameters_Ok()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Get(styleClass.Id)).Returns(styleClass);
            mockFormatDataAccess.Setup(b1 => b1.Get(format.Id)).Returns(format);
            mockFormatDataAccess.Setup(b1 => b1.Modify(format));
            formatBusinessLogic.RemoveStyle(format.Id, styleClass.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStyleClassFromFormat_StyleClassDontExists_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(true);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(false);
            formatBusinessLogic.RemoveStyle(format.Id, styleClass.Id);
        }

        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStyleClassFromFormat_FormatDontExists_ArgumentNullException()
        {
            mockFormatDataAccess.Setup(b1 => b1.Exists(format.Id)).Returns(false);
            mockStyleClassBusinessLogic.Setup(b1 => b1.Exists(styleClass.Id)).Returns(true);
            formatBusinessLogic.RemoveStyle(format.Id, styleClass.Id);
        }
    }
}

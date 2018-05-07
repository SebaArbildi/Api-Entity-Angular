using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;

namespace DocSystTest.DataAccessTest.StyleStructureDataAccessTest
{
    [TestClass]
    public class StyleClassDataAccessTest
    {
        private IStyleClassDataAccess styleClassDataAccess;
        private StyleClass styleClass;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            styleClassDataAccess = new StyleClassDataAccess();
            styleClass = Utils.CreateStyleClassForTest();
        }

        [TestMethod]
        public void AddStyleClass_ExpectedParameters_Ok()
        {
            styleClassDataAccess.Add(styleClass);
            StyleClass obtained = styleClassDataAccess.Get(styleClass.Id);
            Assert.AreEqual(styleClass, obtained);
        }

        [TestMethod]
        public void DeleteStyleClass_ExpectedParameters_Ok()
        {
            styleClassDataAccess.Add(styleClass);
            styleClassDataAccess.Delete(styleClass.Id);
            StyleClass obtained = styleClassDataAccess.Get(styleClass.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void GetStyleClasses_ExpectedParameters_Ok()
        {
            styleClassDataAccess.Add(styleClass);
            IList<StyleClass> specificStyleList = styleClassDataAccess.Get();
            Assert.IsTrue(specificStyleList.Contains(styleClass));
        }

        [TestMethod]
        public void ModifyStyleClass_ExpectedParameters_Ok()
        {

        }
    }
}

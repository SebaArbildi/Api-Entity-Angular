using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;
using DocSystDataAccessImplementation.StyleStructureDataAccess;

namespace DocSystTest.DataAccessTest.StyleStructureDataAccessTest
{
    [TestClass]
    public class StyleDataAccessTest
    {
        private IStyleDataAccess styleDataAccess;
        private Style style;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            styleDataAccess = new StyleDataAccess();
            style = Utils.CreateStyleForTest();
        }

        [TestMethod]
        public void AddStyle_ExpectedParameters_Ok()
        {
            styleDataAccess.Add(style);
            Style obtained = styleDataAccess.Get(style.Name);
            Assert.AreEqual(style, obtained);
        }

        [TestMethod]
        public void DeleteStyle_ExpectedParameters_Ok()
        {
            styleDataAccess.Add(style);
            styleDataAccess.Delete(style.Name);
            Style obtained = styleDataAccess.Get(style.Name);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void GetStyles_ExpectedParameters_Ok()
        {
            styleDataAccess.Add(style);
            IList<Style> specificStyleList = styleDataAccess.Get();
            Assert.IsTrue(specificStyleList.Contains(style));
        }

        [TestMethod]
        public void ModifyStyle_ExpectedParameters_Ok()
        {
            styleDataAccess.Add(style);
            SpecificStyle specificStyle = Utils.CreateSpecificStyleInDataBaseForTest("otherName");
            style.Implementation = specificStyle;
            styleDataAccess.Modify(style);
            Style obtained = styleDataAccess.Get(style.Name);
            Assert.AreEqual(specificStyle, obtained.Implementation);
        }
    }
}
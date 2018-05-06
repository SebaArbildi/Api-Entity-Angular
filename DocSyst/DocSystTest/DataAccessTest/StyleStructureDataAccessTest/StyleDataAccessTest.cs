using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;

namespace DocSystTest.DataAccessTest.StyleStructureDataAccessTest
{
    [TestClass]
    public class StyleDataAccessTest
    {
        private IStyleDataAccess styleDataAccess;
        private Style style;

        private SpecificStyle CreateSpecificStyleForTest()
        {
            return new SpecificStyle("name", "<html><body>{0}</body></html>");
        }

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
            SpecificStyle specificStyle = Utils.CreateSpecificStyleForTest();
            style.Implementation = specificStyle;
            styleDataAccess.Modify(style);
            Style obtained = styleDataAccess.Get(style.Name);
            Assert.AreEqual(style.Name, obtained.Name);
        }
    }
}
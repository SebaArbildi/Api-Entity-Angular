using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;

namespace DocSystTest.DataAccessTest
{
    [TestClass]
    public class StyleStructureDataAccessTest
    {
        private ISpecificStyleDataAccess specificStyleDataAccess;
        private SpecificStyle specificStyle;

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
            specificStyleDataAccess = new SpecificStyleDataAccess();
            specificStyle = CreateSpecificStyleForTest();
        }

        [TestMethod]
        public void AddSpecificStyle_ExpectedParameters_Ok()
        {
            specificStyleDataAccess.Add(specificStyle);
            SpecificStyle obtained = specificStyleDataAccess.Get(specificStyle.Id);
            Assert.AreEqual(specificStyle, obtained);
        }

        [TestMethod]
        public void DeleteSpecificStyle_ExpectedParameters_Ok()
        {
            specificStyleDataAccess.Add(specificStyle);
            specificStyleDataAccess.Delete(specificStyle.Id);
            SpecificStyle obtained = specificStyleDataAccess.Get(specificStyle.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void GetSpecificStyles_ExpectedParameters_Ok()
        {
            specificStyleDataAccess.Add(specificStyle);
            IList<SpecificStyle> specificStyleList = specificStyleDataAccess.Get();
            Assert.IsTrue(specificStyleList.Contains(specificStyle));
        }

        [TestMethod]
        public void ModifySpecificStyles_ExpectedParameters_Ok()
        {
            specificStyleDataAccess.Add(specificStyle);
            specificStyle.Name = "Changed";
            specificStyleDataAccess.Modify(specificStyle);
            SpecificStyle obtained = specificStyleDataAccess.Get(specificStyle.Id);
            Assert.AreEqual(specificStyle.Name, obtained.Name);
        }
    }
}

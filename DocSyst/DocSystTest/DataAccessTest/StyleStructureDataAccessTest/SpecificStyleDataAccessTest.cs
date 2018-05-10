using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessImplementation.StyleStructureDataAccess;

namespace DocSystTest.DataAccessTest
{
    [TestClass]
    public class SpecificStyleDataAccessTest
    {
        private ISpecificStyleDataAccess specificStyleDataAccess;
        private SpecificStyle specificStyle;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            specificStyleDataAccess = new SpecificStyleDataAccess();
            specificStyle = Utils.CreateSpecificStyleForTest("name");
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

        [TestMethod]
        public void ExistsSpecificStyle_ExpectedParameters_Ok()
        {
            specificStyleDataAccess.Add(specificStyle);
            bool obtained = specificStyleDataAccess.Exists(specificStyle.Id);
            Assert.IsTrue(obtained);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;

namespace DocSystTest.DataAccessTest.StyleStructureDataAccessTest
{
    [TestClass]
    public class FormatDataAccessTest
    {
        private IFormatDataAccess formatDataAccess;
        private Format format;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            formatDataAccess = new FormatDataAccess();
            format = Utils.CreateFormatForTest();
        }

        [TestMethod]
        public void AddFormat_ExpectedParameters_Ok()
        {
            formatDataAccess.Add(format);
            Format obtained = formatDataAccess.Get(format.Id);
            Assert.AreEqual(format, obtained);
        }

        [TestMethod]
        public void DeleteFormat_ExpectedParameters_Ok()
        {
            formatDataAccess.Add(format);
            formatDataAccess.Delete(format.Id);
            Format obtained = formatDataAccess.Get(format.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void GetFormats_ExpectedParameters_Ok()
        {
            formatDataAccess.Add(format);
            IList<Format> specificStyleList = formatDataAccess.Get();
            Assert.IsTrue(specificStyleList.Contains(format));
        }

        [TestMethod]
        public void ModifyFormats_ExpectedParameters_Ok()
        {

            formatDataAccess.Modify(format);

        }
    }
}

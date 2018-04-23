using DocSystDataAccess.DocumentStructureDataAccessImplementation;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DocSystTest.DocumentStructureDataAccessTest
{
    [TestClass]
    public class MarginDataAccessTest
    {
        private IMarginDataAccess marginDataAccess;
        private Margin margin;

        [TestInitialize]
        public void TestInitialize()
        {
            marginDataAccess = new MarginDataAccess();
            margin = Utils.CreateMarginForTest();
        }

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestMethod]
        public void CreateMarginDataAccess_WithoutParameters_Ok()
        {
            Assert.IsNotNull(marginDataAccess);
        }

        [TestMethod]
        public void AddMarginToDb_ExpectedParameters_Ok()
        {
            marginDataAccess.Add(margin);

            Margin obtained = marginDataAccess.Get(margin.Id);
            Assert.AreEqual(margin, obtained);
        }

        [TestMethod]
        public void DeleteMarginFromDb_ExpectedParameters_Ok()
        {
            marginDataAccess.Add(margin);

            marginDataAccess.Delete(margin.Id);

            Margin obtained = marginDataAccess.Get(margin.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyMarginFromDb_ExpectedParameters_Ok()
        {
            marginDataAccess.Add(margin);
            margin.OwnStyleClass = "other Style Class";

            marginDataAccess.Modify(margin);

            Margin obtained = marginDataAccess.Get(margin.Id);
            Assert.AreEqual(margin, obtained);
        }

        [TestMethod]
        public void GetAllMarginsFromDb_ExpectedParameters_Ok()
        {
            marginDataAccess.Add(margin);

            IList<Margin> margins = marginDataAccess.Get();

            Assert.IsTrue(margins.Contains(margin));
        }

        [TestMethod]
        public void ExistMarginInDb_ExpectedParameters_Ok()
        {
            marginDataAccess.Add(margin);

            bool exists = marginDataAccess.Exists(margin.Id);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            Margin margin1 = Utils.CreateMarginForTest();
            Margin margin2 = Utils.CreateMarginForTest();
            Margin margin3 = Utils.CreateMarginForTest();
            marginDataAccess.Add(margin1);
            marginDataAccess.Add(margin2);
            marginDataAccess.Add(margin3);

            margin1.OwnStyleClass = "other Style Class";
            marginDataAccess.Modify(margin1);
            Assert.AreEqual(margin1, marginDataAccess.Get(margin1.Id));

            marginDataAccess.Delete(margin2.Id);
            IList<Margin> users = marginDataAccess.Get();

            Assert.IsFalse(users.Contains(margin2));
            Assert.IsFalse(marginDataAccess.Exists(margin2.Id));
            Assert.IsTrue(users.Contains(margin1));
            Assert.IsTrue(marginDataAccess.Exists(margin1.Id));
        }
    }
}

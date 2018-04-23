using DocSystDataAccess.DocumentStructureDataAccessImplementation;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DocSystTest.DocumentStructureDataAccessTest
{
    [TestClass]
    public class ParagraphDataAccessTest
    {
        private IParagraphDataAccess paragraphDataAccess;
        private Paragraph paragraph;

        [TestInitialize]
        public void TestInitialize()
        {
            paragraphDataAccess = new ParagraphDataAccess();
            paragraph = Utils.CreateParagraphForTest();
        }

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestMethod]
        public void CreateParagraphDataAccess_WithoutParameters_Ok()
        {
            Assert.IsNotNull(paragraphDataAccess);
        }

        [TestMethod]
        public void AddParagraphToDb_ExpectedParameters_Ok()
        {
            paragraphDataAccess.Add(paragraph);

            Paragraph obtained = paragraphDataAccess.Get(paragraph.Id);
            Assert.AreEqual(paragraph, obtained);
        }

        [TestMethod]
        public void DeleteParagraphFromDb_ExpectedParameters_Ok()
        {
            paragraphDataAccess.Add(paragraph);

            paragraphDataAccess.Delete(paragraph.Id);

            Paragraph obtained = paragraphDataAccess.Get(paragraph.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyParagraphFromDb_ExpectedParameters_Ok()
        {
            paragraphDataAccess.Add(paragraph);
            paragraph.OwnStyleClass = "other Style Class";

            paragraphDataAccess.Modify(paragraph);

            Paragraph obtained = paragraphDataAccess.Get(paragraph.Id);
            Assert.AreEqual(paragraph, obtained);
        }

        [TestMethod]
        public void GetAllParagraphsFromDb_ExpectedParameters_Ok()
        {
            paragraphDataAccess.Add(paragraph);

            IList<Paragraph> paragraphs = paragraphDataAccess.Get();

            Assert.IsTrue(paragraphs.Contains(paragraph));
        }

        [TestMethod]
        public void ExistParagraphInDb_ExpectedParameters_Ok()
        {
            paragraphDataAccess.Add(paragraph);

            bool exists = paragraphDataAccess.Exists(paragraph.Id);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            Paragraph paragraph1 = Utils.CreateParagraphForTest();
            Paragraph paragraph2 = Utils.CreateParagraphForTest();
            Paragraph paragraph3 = Utils.CreateParagraphForTest();
            paragraphDataAccess.Add(paragraph1);
            paragraphDataAccess.Add(paragraph2);
            paragraphDataAccess.Add(paragraph3);

            paragraph1.OwnStyleClass = "other Style Class";
            paragraphDataAccess.Modify(paragraph1);
            Assert.AreEqual(paragraph1, paragraphDataAccess.Get(paragraph1.Id));

            paragraphDataAccess.Delete(paragraph2.Id);
            IList<Paragraph> paragraphs = paragraphDataAccess.Get();

            Assert.IsFalse(paragraphs.Contains(paragraph2));
            Assert.IsFalse(paragraphDataAccess.Exists(paragraph2.Id));
            Assert.IsTrue(paragraphs.Contains(paragraph1));
            Assert.IsTrue(paragraphDataAccess.Exists(paragraph1.Id));
        }
    }
}

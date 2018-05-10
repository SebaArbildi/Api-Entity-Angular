using DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DocSystTest.DocumentStructureDataAccessTest
{
    [TestClass]
    public class TextDataAccessTest
    {
        private ITextDataAccess textDataAccess;
        private Text text;

        [TestInitialize]
        public void TestInitialize()
        {
            textDataAccess = new TextDataAccess();
            text = Utils.CreateTextForTest();
        }

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestMethod]
        public void CreateTextDataAccess_WithoutParameters_Ok()
        {
            Assert.IsNotNull(textDataAccess);
        }

        [TestMethod]
        public void AddTextToDb_ExpectedParameters_Ok()
        {
            textDataAccess.Add(text);

            Text obtained = textDataAccess.Get(text.Id);
            Assert.AreEqual(text, obtained);
        }

        [TestMethod]
        public void DeleteTextFromDb_ExpectedParameters_Ok()
        {
            textDataAccess.Add(text);

            textDataAccess.Delete(text.Id);

            Text obtained = textDataAccess.Get(text.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyTextFromDb_ExpectedParameters_Ok()
        {
            textDataAccess.Add(text);
            text.TextContent = "other Paragraph Content";

            textDataAccess.Modify(text);

            Text obtained = textDataAccess.Get(text.Id);
            Assert.AreEqual(text, obtained);
        }

        [TestMethod]
        public void GetAllTextsFromDb_ExpectedParameters_Ok()
        {
            textDataAccess.Add(text);

            IList<Text> texts = textDataAccess.Get();

            Assert.IsTrue(texts.Contains(text));
        }

        [TestMethod]
        public void ExistTextInDb_ExpectedParameters_Ok()
        {
            textDataAccess.Add(text);

            bool exists = textDataAccess.Exists(text.Id);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            Text text1 = Utils.CreateTextForTest();
            Text text2 = Utils.CreateTextForTest();
            Text text3 = Utils.CreateTextForTest();
            textDataAccess.Add(text1);
            textDataAccess.Add(text2);
            textDataAccess.Add(text3);

            text1.TextContent = "other Paragraph Content";
            textDataAccess.Modify(text1);
            Assert.AreEqual(text1, textDataAccess.Get(text1.Id));

            textDataAccess.Delete(text2.Id);
            IList<Text> texts = textDataAccess.Get();

            Assert.IsFalse(texts.Contains(text2));
            Assert.IsFalse(textDataAccess.Exists(text2.Id));
            Assert.IsTrue(texts.Contains(text1));
            Assert.IsTrue(textDataAccess.Exists(text1.Id));
        }
    }
}

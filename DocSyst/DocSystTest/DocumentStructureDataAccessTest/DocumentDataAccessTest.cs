using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystDataAccess.DocumentStructureDataAccessImplementation;

namespace DocSystTest.DocumentStructureDataAccessTest
{
    [TestClass]
    public class DocumentDataAccessTest
    {
        private IDocumentDataAccess documentDataAccess;
        private Document document;

        [TestInitialize]
        public void TestInitialize()
        {
            documentDataAccess = new DocumentDataAccess();
            document = Utils.CreateDocumentForTest();
        }

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestMethod]
        public void CreateDocumentDataAccess_WithoutParameters_Ok()
        {
            Assert.IsNotNull(documentDataAccess);
        }

        [TestMethod]
        public void AddDocumentToDb_ExpectedParameters_Ok()
        {
            documentDataAccess.Add(document);

            Document obtained = documentDataAccess.Get(document.Id);
            Assert.AreEqual(document, obtained);
        }

        [TestMethod]
        public void DeleteDocumentFromDb_ExpectedParameters_Ok()
        {
            documentDataAccess.Add(document);

            documentDataAccess.Delete(document.Id);

            Document obtained = documentDataAccess.Get(document.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyDocumentFromDb_ExpectedParameters_Ok()
        {
            documentDataAccess.Add(document);
            document.OwnStyleClass = "other Style Class";

            documentDataAccess.Modify(document);

            Document obtained = documentDataAccess.Get(document.Id);
            Assert.AreEqual(document, obtained);
        }

        [TestMethod]
        public void GetAllDocumentsFromDb_ExpectedParameters_Ok()
        {
            documentDataAccess.Add(document);

            IList<Document> documents = documentDataAccess.Get();

            Assert.IsTrue(documents.Contains(document));
        }

        [TestMethod]
        public void ExistDocumentInDb_ExpectedParameters_Ok()
        {
            documentDataAccess.Add(document);

            bool exists = documentDataAccess.Exists(document.Id);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            Document document1 = Utils.CreateDocumentForTest();
            Document document2 = Utils.CreateDocumentForTest();
            Document document3 = Utils.CreateDocumentForTest();
            documentDataAccess.Add(document1);
            documentDataAccess.Add(document2);
            documentDataAccess.Add(document3);

            document1.OwnStyleClass = "other Style Class";
            documentDataAccess.Modify(document1);
            Assert.AreEqual(document1, documentDataAccess.Get(document1.Id));

            documentDataAccess.Delete(document2.Id);
            IList<Document> users = documentDataAccess.Get();

            Assert.IsFalse(users.Contains(document2));
            Assert.IsFalse(documentDataAccess.Exists(document2.Id));
            Assert.IsTrue(users.Contains(document1));
            Assert.IsTrue(documentDataAccess.Exists(document1.Id));
        }
    }
}

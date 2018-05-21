using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestDocument
    {
        List<Body> someDocumentMargin;
        List<Paragraph> someDocumentParagraph;
        string aStyleClass;
        string aTitle;
        Margin aMargin;
        Paragraph aParagraph;
        User aUser;

        [TestInitialize]
        public void TestInitialize()
        {
            someDocumentMargin = new List<Body>();
            someDocumentParagraph = new List<Paragraph>();
            aStyleClass = "a Style Class";
            aTitle = "a Title";
            aMargin = new Margin(MarginAlign.FOOTER);
            aParagraph = new Paragraph(MarginAlign.PARAGRAPH);
            aUser = Utils.CreateUserForTest();
        }


        [TestMethod]
        public void CreateDocument_WhitoutParameter_Ok()
        {
            Document aDoc = new Document();

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.IsNull(aDoc.Title);
            Assert.IsTrue(aDoc.DocumentMargins.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_OnlyWhitTitle_Ok()
        {
            Document aDoc = new Document(aTitle,aUser);

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.AreEqual(aDoc.Title,aTitle);
            Assert.IsTrue(aDoc.DocumentMargins.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleAndStyle_Ok()
        {
            Document aDoc = new Document(aTitle,aStyleClass,aUser);

            Assert.IsNotNull(aDoc.Id);
            Assert.AreEqual(aDoc.OwnStyleClass, aStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.IsTrue(aDoc.DocumentMargins.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleAndSomeParts_Ok()
        {
            someDocumentMargin.Add(aMargin);
            someDocumentParagraph.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentMargin, someDocumentParagraph, aUser);

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.AreEqual(aDoc.DocumentMargins, someDocumentMargin);
            Assert.AreEqual(aDoc.DocumentParagraphs, someDocumentParagraph);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleSomePartsAndStyle_Ok()
        {
            someDocumentMargin.Add(aMargin);
            someDocumentParagraph.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentMargin, someDocumentParagraph, aStyleClass, aUser);

            Assert.IsNotNull(aDoc.Id);
            Assert.AreEqual(aDoc.OwnStyleClass, aStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.AreEqual(aDoc.DocumentMargins, someDocumentMargin);
            Assert.AreEqual(aDoc.DocumentParagraphs, someDocumentParagraph);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartFooter_Ok()
        {
            someDocumentMargin.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.AreEqual(aDoc.GetDocumentMargin(MarginAlign.FOOTER), aMargin);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartFooter_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);
            aDoc.GetDocumentMargin(MarginAlign.FOOTER);
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartHeader_Ok()
        {
            aMargin.Align = MarginAlign.HEADER;
            someDocumentMargin.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.AreEqual(aDoc.GetDocumentMargin(MarginAlign.HEADER), aMargin);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartHeader_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);
            aDoc.GetDocumentMargin(MarginAlign.HEADER);
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartParagraph_Ok()
        {
            someDocumentMargin.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.AreEqual(aDoc.GetDocumentMargin(MarginAlign.PARAGRAPH), aParagraph);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartParagraph_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);
            aDoc.GetDocumentMargin(MarginAlign.PARAGRAPH);
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistParagraph_Ok()
        {
            someDocumentParagraph.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParagraph, aStyleClass,aUser);

            Assert.IsTrue(aDoc.ExistDocumentParagraph(aParagraph));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistParagraph_Ok()
        {
            Document aDoc = new Document(aTitle, someDocumentParagraph, aStyleClass,aUser);

            Assert.IsFalse(aDoc.ExistDocumentParagraph(aParagraph));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistFooter_Ok()
        {
            someDocumentMargin.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.IsTrue(aDoc.ExistDocumentMargin(MarginAlign.FOOTER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistFooter_Ok()
        {
            someDocumentMargin.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.IsFalse(aDoc.ExistDocumentMargin(MarginAlign.HEADER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistHeader_Ok()
        {
            someDocumentMargin.Add(aMargin);
            aMargin.Align = MarginAlign.HEADER;
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass,aUser);

            Assert.IsTrue(aDoc.ExistDocumentMargin(MarginAlign.HEADER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistHeader_Ok()
        {
            someDocumentMargin.Add(aMargin);
            aMargin.Align = MarginAlign.HEADER;
            Document aDoc = new Document(aTitle, someDocumentMargin, aStyleClass, aUser);

            Assert.IsFalse(aDoc.ExistDocumentMargin(MarginAlign.FOOTER));
        }
    }
}

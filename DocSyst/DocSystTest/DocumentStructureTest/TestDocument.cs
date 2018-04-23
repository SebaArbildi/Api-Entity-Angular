using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestDocument
    {
        List<Body> someDocumentParts;
        string aStyleClass;
        string aTitle;
        Margin aMargin;
        Margin aParagraph;

        [TestInitialize]
        public void TestInitialize()
        {
            someDocumentParts = new List<Body>();
            aStyleClass = "a Style Class";
            aTitle = "a Title";
            aMargin = new Margin(MarginAlign.FOOTER);
            aParagraph = new Margin(MarginAlign.PARAGRAPH);
        }


        [TestMethod]
        public void CreateDocument_WhitoutParameter_Ok()
        {
            Document aDoc = new Document();

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.IsNull(aDoc.Title);
            Assert.IsTrue(aDoc.DocumentParts.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_OnlyWhitTitle_Ok()
        {
            Document aDoc = new Document(aTitle);

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.AreEqual(aDoc.Title,aTitle);
            Assert.IsTrue(aDoc.DocumentParts.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleAndStyle_Ok()
        {
            Document aDoc = new Document(aTitle,aStyleClass);

            Assert.IsNotNull(aDoc.Id);
            Assert.AreEqual(aDoc.OwnStyleClass, aStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.IsTrue(aDoc.DocumentParts.Count == 0);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleAndSomeParts_Ok()
        {
            someDocumentParts.Add(aMargin);
            someDocumentParts.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParts);

            Assert.IsNotNull(aDoc.Id);
            Assert.IsNull(aDoc.OwnStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.AreEqual(aDoc.DocumentParts,someDocumentParts);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void CreateDocument_WhitTitleSomePartsAndStyle_Ok()
        {
            someDocumentParts.Add(aMargin);
            someDocumentParts.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsNotNull(aDoc.Id);
            Assert.AreEqual(aDoc.OwnStyleClass, aStyleClass);
            Assert.AreEqual(aDoc.Title, aTitle);
            Assert.AreEqual(aDoc.DocumentParts, someDocumentParts);
            Assert.IsTrue((aDoc.CreationDate.Year == DateTime.Today.Year) && (aDoc.CreationDate.Month == DateTime.Today.Month) && (aDoc.CreationDate.Day == DateTime.Today.Day));
            Assert.IsTrue((aDoc.LastModifyDate.Year == DateTime.Today.Year) && (aDoc.LastModifyDate.Month == DateTime.Today.Month) && (aDoc.LastModifyDate.Day == DateTime.Today.Day));
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartFooter_Ok()
        {
            someDocumentParts.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.AreEqual(aDoc.GetDocumentPart(MarginAlign.FOOTER), aMargin);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartFooter_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);
            aDoc.GetDocumentPart(MarginAlign.FOOTER);
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartHeader_Ok()
        {
            aMargin.Align = MarginAlign.HEADER;
            someDocumentParts.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.AreEqual(aDoc.GetDocumentPart(MarginAlign.HEADER), aMargin);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartHeader_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);
            aDoc.GetDocumentPart(MarginAlign.HEADER);
        }

        [TestMethod]
        public void GetDocumentPart_WhenDocumentHasPartParagraph_Ok()
        {
            someDocumentParts.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.AreEqual(aDoc.GetDocumentPart(MarginAlign.PARAGRAPH), aParagraph);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Given margin align not exist in this document.")]
        public void GetDocumentPart_WhenDocumentHasPartParagraph_KeyNotFoundException()
        {
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);
            aDoc.GetDocumentPart(MarginAlign.PARAGRAPH);
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistParagraph_Ok()
        {
            someDocumentParts.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsTrue(aDoc.ExistDocumentPart(MarginAlign.PARAGRAPH));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistParagraph_Ok()
        {
            someDocumentParts.Add(aParagraph);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsFalse(aDoc.ExistDocumentPart(MarginAlign.FOOTER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistFooter_Ok()
        {
            someDocumentParts.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsTrue(aDoc.ExistDocumentPart(MarginAlign.FOOTER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistFooter_Ok()
        {
            someDocumentParts.Add(aMargin);
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsFalse(aDoc.ExistDocumentPart(MarginAlign.PARAGRAPH));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartExistHeader_Ok()
        {
            someDocumentParts.Add(aMargin);
            aMargin.Align = MarginAlign.HEADER;
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsTrue(aDoc.ExistDocumentPart(MarginAlign.HEADER));
        }

        [TestMethod]
        public void ExistDocPart_WhenDocPartNotExistHeader_Ok()
        {
            someDocumentParts.Add(aMargin);
            aMargin.Align = MarginAlign.HEADER;
            Document aDoc = new Document(aTitle, someDocumentParts, aStyleClass);

            Assert.IsFalse(aDoc.ExistDocumentPart(MarginAlign.PARAGRAPH));
        }
    }
}

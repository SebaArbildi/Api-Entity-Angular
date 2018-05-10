using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestParagraph
    {
        List<Text> someTexts;
        string aStyleClass;
        Text aText;

        [TestInitialize]
        public void TestInitialize()
        {
            someTexts = new List<Text>();
            aStyleClass = "a Style Class";
            aText = new Text();
        }

        [TestMethod]
        public void CreateParagraph_WhitOutParameters_Ok()
        {
            Margin aBodyParagraph = new Margin();

            Assert.IsNotNull(aBodyParagraph.Id);
            Assert.IsNull(aBodyParagraph.Align);
            Assert.IsNull(aBodyParagraph.OwnStyleClass);
            Assert.IsTrue(aBodyParagraph.Texts.Count==0);
        }

        [TestMethod]
        public void CreateUser_WhitSomeTexts_Ok()
        {
            Margin aBodyParagraph = new Margin(MarginAlign.PARAGRAPH,someTexts);

            Assert.IsNotNull(aBodyParagraph.Id);
            Assert.AreEqual(aBodyParagraph.Align, MarginAlign.PARAGRAPH);
            Assert.IsNull(aBodyParagraph.OwnStyleClass);
            Assert.AreEqual(aBodyParagraph.Texts, someTexts);
        }

        [TestMethod]
        public void CreateUser_WhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyParagraph = new Margin(MarginAlign.PARAGRAPH, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyParagraph.Id);
            Assert.AreEqual(aBodyParagraph.Align, MarginAlign.PARAGRAPH);
            Assert.AreEqual(aBodyParagraph.OwnStyleClass, aStyleClass);
            Assert.AreEqual(aBodyParagraph.Texts, someTexts);
        }

        [TestMethod]
        public void GetText_FromParagraphWhitSomeText_Ok()
        {
            someTexts.Add(aText);
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            Assert.AreEqual(aBodyParagraph.GetText(aText.Id),aText);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Paragraph id not found for this Paragraph List.")]
        public void GetText_FromParagraphWhitSomeText_KeyNotFoundException()
        {
            someTexts.Add(aText);
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.GetText(new Guid());
        }

        [TestMethod]
        public void GetTextAt_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            someTexts.Add(aText);
            someTexts.Add(otherText);

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            Assert.AreEqual(aBodyParagraph.GetTextAt(1), otherText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Paragraph not found at given index.")]
        public void GetTextAt_FromParagraphWhitText_IndexOutOfRangeException()
        {
            someTexts.Add(aText);

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.GetTextAt(1);
        }

        [TestMethod]
        public void PutTextAt_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAt(0, aText);
            aBodyParagraph.PutTextAt(0, otherText);

            Assert.AreEqual(aBodyParagraph.GetTextAt(0), otherText);
            Assert.AreEqual(aBodyParagraph.GetTextAt(1), aText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Given index is bigger than list length.")]
        public void PutTextAt_FromParagraphWhitOutText_IndexOutOfRangeException()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAt(0, aText);
            aBodyParagraph.PutTextAt(2, otherText);
        }

        [TestMethod]
        public void PutTextAtLast_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAtLast(aText);
            aBodyParagraph.PutTextAtLast(otherText);

            Assert.AreEqual(aBodyParagraph.GetTextAt(1), otherText);
            Assert.AreEqual(aBodyParagraph.GetTextAt(0), aText);
        }

        [TestMethod]
        public void MoveTextTo_FromParagraphWhitText_Ok()
        {
            Text otherText = new Text();
            Text oneMoreText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAtLast(aText);
            aBodyParagraph.PutTextAtLast(otherText);
            aBodyParagraph.PutTextAtLast(oneMoreText);

            aBodyParagraph.MoveTextTo(0,oneMoreText.Id);
            aBodyParagraph.MoveTextTo(2, otherText.Id);

            Assert.AreEqual(aBodyParagraph.GetTextAt(2), otherText);
            Assert.AreEqual(aBodyParagraph.GetTextAt(0), oneMoreText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Given index is bigger than list length.")]
        public void MoveTextTo_FromParagraphWhitText_IndexOutOfRangeException()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAtLast(aText);
            aBodyParagraph.PutTextAtLast(otherText);

            aBodyParagraph.MoveTextTo(2, aText.Id);
        }

        [TestMethod]
        public void ExistText_WhenTextExist_Ok()
        {
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAtLast(aText);

            Assert.IsTrue(aBodyParagraph.ExistText(aText.Id));
        }

        [TestMethod]
        public void ExistText_WhenTextNotExist_Ok()
        {
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.PutTextAtLast(aText);

            Assert.IsFalse(aBodyParagraph.ExistText(Guid.NewGuid()));
        }
    }
}

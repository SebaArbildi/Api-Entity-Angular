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

            Assert.IsNotNull(aBodyParagraph.id);
            Assert.IsNull(aBodyParagraph.Align);
            Assert.IsNull(aBodyParagraph.ownStyleClass);
            Assert.IsTrue(aBodyParagraph.texts.Count==0);
        }

        [TestMethod]
        public void CreateUser_WhitSomeTexts_Ok()
        {
            Margin aBodyParagraph = new Margin(MarginAlign.PARAGRAPH,someTexts);

            Assert.IsNotNull(aBodyParagraph.id);
            Assert.Equals(aBodyParagraph.Align, MarginAlign.PARAGRAPH);
            Assert.IsNull(aBodyParagraph.ownStyleClass);
            Assert.AreEqual(aBodyParagraph.texts, someTexts);
        }

        [TestMethod]
        public void CreateUser_WhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyParagraph = new Margin(MarginAlign.PARAGRAPH, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyParagraph.id);
            Assert.Equals(aBodyParagraph.Align, MarginAlign.PARAGRAPH);
            Assert.AreEqual(aBodyParagraph.ownStyleClass, aStyleClass);
            Assert.AreEqual(aBodyParagraph.texts, someTexts);
        }

        [TestMethod]
        public void GetText_FromParagraphWhitSomeText_Ok()
        {
            someTexts.Add(aText);
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            Assert.AreEqual(aBodyParagraph.getText(aText.id),aText);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException),
        "Text id not found for this Paragraph List.")]
        public void GetText_FromParagraphWhitSomeText_KeyNotFoundException()
        {
            someTexts.Add(aText);
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.getText(new Guid());
        }

        [TestMethod]
        public void GetTextAt_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            someTexts.Add(aText);
            someTexts.Add(otherText);

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            Assert.AreEqual(aBodyParagraph.getTextAt(1), otherText);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
        "Text not found at given index.")]
        public void GetTextAt_FromParagraphWhitText_IndexOutOfRangeException()
        {
            someTexts.Add(aText);

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.getTextAt(1);
        }

        [TestMethod]
        public void PutTextAt_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAt(0, aText);
            aBodyParagraph.putTextAt(0, otherText);

            Assert.AreEqual(aBodyParagraph.getTextAt(0), otherText);
            Assert.AreEqual(aBodyParagraph.getTextAt(1), aText);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
        "Given index is bigger than list length.")]
        public void PutTextAt_FromParagraphWhitOutText_IndexOutOfRangeException()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAt(0, aText);
            aBodyParagraph.putTextAt(2, otherText);
        }

        [TestMethod]
        public void PutTextAtLast_FromParagraphWhitOutText_Ok()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAtLast(aText);
            aBodyParagraph.putTextAtLast(otherText);

            Assert.AreEqual(aBodyParagraph.getTextAt(1), otherText);
            Assert.AreEqual(aBodyParagraph.getTextAt(0), aText);
        }

        [TestMethod]
        public void moveTextTo_FromParagraphWhitText_Ok()
        {
            Text otherText = new Text();
            Text oneMoreText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAtLast(aText);
            aBodyParagraph.putTextAtLast(otherText);
            aBodyParagraph.putTextAtLast(oneMoreText);

            aBodyParagraph.moveTextTo(0,oneMoreText.id);
            aBodyParagraph.moveTextTo(2, otherText.id);

            Assert.AreEqual(aBodyParagraph.getTextAt(1), otherText);
            Assert.AreEqual(aBodyParagraph.getTextAt(0), aText);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
        "Given index is bigger than list length.")]
        public void moveTextTo_FromParagraphWhitText_IndexOutOfRangeException()
        {
            Text otherText = new Text();

            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAtLast(aText);
            aBodyParagraph.putTextAtLast(otherText);

            aBodyParagraph.moveTextTo(2, aText.id);
        }

        [TestMethod]
        public void ExistText_WhenTextExist_Ok()
        {
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAtLast(aText);

            Assert.IsTrue(aBodyParagraph.ExistText(aText.id));
        }

        [TestMethod]
        public void ExistText_WhenTextNotExist_Ok()
        {
            Paragraph aBodyParagraph = new Paragraph(MarginAlign.PARAGRAPH, someTexts);

            aBodyParagraph.putTextAtLast(aText);

            Assert.IsTrue(aBodyParagraph.ExistText(new Guid()));
        }
    }
}

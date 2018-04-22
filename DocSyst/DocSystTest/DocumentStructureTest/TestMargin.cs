using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestMargin
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
        public void CreateMargin_WhitOutParameters_Ok ()
        {
            Margin aBodyMargin = new Margin();

            Assert.IsNotNull(aBodyMargin.id);
            Assert.IsNull(aBodyMargin.ownStyleClass);
            Assert.IsTrue(aBodyMargin.texts.Count==0);
            Assert.IsNull(aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterEmpty_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.IsNull(aBodyMargin.ownStyleClass);
            Assert.IsTrue(aBodyMargin.texts.Count == 0);
            Assert.AreEqual(MarginAlign.FOOTER,aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderEmpty_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.IsNull(aBodyMargin.ownStyleClass);
            Assert.IsTrue(aBodyMargin.texts.Count == 0);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderWhitSomeTexts_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER,someTexts);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.IsNull(aBodyMargin.ownStyleClass);
            Assert.AreEqual(aBodyMargin.texts,someTexts);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterWhitSomeTexts_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.IsNull(aBodyMargin.ownStyleClass);
            Assert.AreEqual(aBodyMargin.texts,someTexts);
            Assert.AreEqual(MarginAlign.FOOTER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterWhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.AreEqual(aBodyMargin.ownStyleClass,aStyleClass);
            Assert.AreEqual(aBodyMargin.texts,someTexts);
            Assert.AreEqual(MarginAlign.FOOTER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderWhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyMargin.id);
            Assert.AreEqual(aBodyMargin.ownStyleClass,aStyleClass);
            Assert.AreEqual(aBodyMargin.texts,someTexts);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void SetAndGetText_OnHeader_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER,someTexts);

            aBodyMargin.setText(aText);

            Assert.AreEqual(aText, aBodyMargin.getText());
        }

        [TestMethod]
        public void SetAndGetText_OnFooter_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.setText(aText);

            Assert.AreEqual(aText, aBodyMargin.getText());
        }

        [TestMethod]
        public void ClearText_OnHeaderWhitSomeText_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER, someTexts);

            aBodyMargin.setText(aText);
            aBodyMargin.clearText();

            Assert.IsNull(aBodyMargin.getText());
        }

        [TestMethod]
        public void ClearText_OnFooterWhitSomeText_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.setText(aText);
            aBodyMargin.clearText();

            Assert.IsNull(aBodyMargin.getText());
        }

        [TestMethod]
        public void ExistText_WhenTextExist_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.setText(aText);

            Assert.IsTrue(aBodyMargin.ExistText(aText.id));
        }

        [TestMethod]
        public void ExistText_WhenTextNotExist_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.setText(aText);

            Assert.IsTrue(aBodyMargin.ExistText(new Guid()));
        }
    }
}

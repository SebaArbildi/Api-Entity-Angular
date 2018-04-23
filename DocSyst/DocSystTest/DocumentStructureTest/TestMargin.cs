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

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.IsNull(aBodyMargin.OwnStyleClass);
            Assert.IsTrue(aBodyMargin.Texts.Count==0);
            Assert.IsNull(aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterEmpty_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.IsNull(aBodyMargin.OwnStyleClass);
            Assert.IsTrue(aBodyMargin.Texts.Count == 0);
            Assert.AreEqual(MarginAlign.FOOTER,aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderEmpty_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.IsNull(aBodyMargin.OwnStyleClass);
            Assert.IsTrue(aBodyMargin.Texts.Count == 0);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderWhitSomeTexts_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER,someTexts);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.IsNull(aBodyMargin.OwnStyleClass);
            Assert.AreEqual(aBodyMargin.Texts,someTexts);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterWhitSomeTexts_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.IsNull(aBodyMargin.OwnStyleClass);
            Assert.AreEqual(aBodyMargin.Texts,someTexts);
            Assert.AreEqual(MarginAlign.FOOTER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsFooterWhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.AreEqual(aBodyMargin.OwnStyleClass,aStyleClass);
            Assert.AreEqual(aBodyMargin.Texts,someTexts);
            Assert.AreEqual(MarginAlign.FOOTER, aBodyMargin.Align);
        }

        [TestMethod]
        public void CreateMargin_AsHeaderWhitSomeTextsAndStyle_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER, someTexts, aStyleClass);

            Assert.IsNotNull(aBodyMargin.Id);
            Assert.AreEqual(aBodyMargin.OwnStyleClass,aStyleClass);
            Assert.AreEqual(aBodyMargin.Texts,someTexts);
            Assert.AreEqual(MarginAlign.HEADER, aBodyMargin.Align);
        }

        [TestMethod]
        public void SetAndGetText_OnHeader_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER,someTexts);

            aBodyMargin.SetText(aText);

            Assert.AreEqual(aText, aBodyMargin.GetText());
        }

        [TestMethod]
        public void SetAndGetText_OnFooter_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.SetText(aText);

            Assert.AreEqual(aText, aBodyMargin.GetText());
        }

        [TestMethod]
        public void ClearText_OnHeaderWhitSomeText_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.HEADER, someTexts);

            aBodyMargin.SetText(aText);
            aBodyMargin.ClearText();

            Assert.IsFalse(aBodyMargin.HasText());
        }

        [TestMethod]
        public void ClearText_OnFooterWhitSomeText_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.SetText(aText);
            aBodyMargin.ClearText();

            Assert.IsFalse(aBodyMargin.HasText());
        }

        [TestMethod]
        public void ExistText_WhenTextExist_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.SetText(aText);

            Assert.IsTrue(aBodyMargin.ExistText(aText.Id));
        }

        [TestMethod]
        public void ExistText_WhenTextNotExist_Ok()
        {
            Margin aBodyMargin = new Margin(MarginAlign.FOOTER, someTexts);

            aBodyMargin.SetText(aText);

            Assert.IsFalse(aBodyMargin.ExistText(Guid.NewGuid()));
        }
    }
}

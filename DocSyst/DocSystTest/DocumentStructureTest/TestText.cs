using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.DocumentStructure;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestText
    {
        string aStyle;
        string aTextContent;

        [TestInitialize]
        public void TestInitialize()
        {
            aStyle = "StyleClass";
            aTextContent = "a random text";
        }

        [TestMethod]
        public void CreateText_WhitoutParameters_Ok()
        {
            Text aText = new Text();

            Assert.IsNull(aText.ownStyleClass);
            Assert.IsNull(aText.textContent);
            Assert.IsNotNull(aText.id);
        }
        

        [TestMethod]
        public void CreateText_OnlyWhitTextContent_Ok()
        {
            Text aText = new Text(aTextContent);

            Assert.IsNotNull(aText.id);
            Assert.IsNull(aText.ownStyleClass);
            Assert.AreEqual(aTextContent, aText.textContent);
        }

        [TestMethod]
        public void CreateText_WhitTextContentAndStyle_Ok()
        {
            Text aText = new Text(aTextContent, aStyle);

            Assert.IsNotNull(aText.id);
            Assert.AreEqual(aStyle,aText.ownStyleClass);
            Assert.AreEqual(aTextContent, aText.textContent);
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsNotEmpty_Ok()
        {
            Text aText = new Text(aTextContent);

            Assert.IsFalse(aText.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsEmpty_Ok()
        {
            aTextContent = "";
            Text aText = new Text(aTextContent);

            Assert.IsTrue(aText.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsNull_Ok()
        {
            aTextContent = null;
            Text aText = new Text(aTextContent);

            Assert.IsTrue(aText.IsEmpty());
        }

        [TestMethod]
        public void Equals_WhenAreEqual_Ok()
        {
            Text aText = new Text();
            Text otherText = new Text();

            otherText.id = aText.id;

            Assert.IsTrue(aText.Equals(otherText));
        }

        [TestMethod]
        public void Equals_WhenAreNotEqual_Ok()
        {
            Text aText = new Text();
            Text otherText = new Text();

            Assert.IsFalse(aText.Equals(otherText));
        }
    }
}

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
            aTextContent = "a random paragraph";
        }

        [TestMethod]
        public void CreateText_WhitoutParameters_Ok()
        {
            Text aText = new Text();

            Assert.IsNull(aText.OwnStyleClass);
            Assert.IsNull(aText.TextContent);
            Assert.IsNotNull(aText.Id);
        }
        

        [TestMethod]
        public void CreateText_OnlyWhitTextContent_Ok()
        {
            Text aText = new Text(aTextContent);

            Assert.IsNotNull(aText.Id);
            Assert.IsNull(aText.OwnStyleClass);
            Assert.AreEqual(aTextContent, aText.TextContent);
        }

        [TestMethod]
        public void CreateText_WhitTextContentAndStyle_Ok()
        {
            Text aText = new Text(aTextContent, aStyle);

            Assert.IsNotNull(aText.Id);
            Assert.AreEqual(aStyle,aText.OwnStyleClass);
            Assert.AreEqual(aTextContent, aText.TextContent);
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
            Text otherText = new Text
            {
                Id = aText.Id
            };

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

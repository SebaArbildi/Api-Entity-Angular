using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.DocumentStructure;

namespace DocSystTest.DocumentStructureTest
{
    [TestClass]
    public class TestText
    {

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
            Text aText = new Text("a random Text");

            Assert.IsNotNull(aText.id);
            Assert.IsNull(aText.ownStyleClass);
            Assert.AreEqual("a random Text", aText.textContent);
        }

        [TestMethod]
        public void CreateText_WhitTextContentAndStyle_Ok()
        {
            string aStyle = "StyleClass";
            string aTextContent = "a random text";
            Text aText = new Text(aTextContent, aStyle);

            Assert.IsNotNull(aText.id);
            Assert.AreEqual(aStyle,aText.ownStyleClass);
            Assert.AreEqual(aTextContent, aText.textContent);
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsNotEmpty_Ok()
        {
            string aTextContent = "a random text";
            Text aText = new Text(aTextContent);

            Assert.IsFalse(aText.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsEmpty_Ok()
        {
            string aTextContent = "";
            Text aText = new Text(aTextContent);

            Assert.IsTrue(aText.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WhenTextIsNull_Ok()
        {
            string aTextContent = null;
            Text aText = new Text(aTextContent);

            Assert.IsTrue(aText.IsEmpty());
        }
    }
}

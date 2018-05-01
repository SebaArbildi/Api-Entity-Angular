using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;

namespace DocSystTest.EntitiesTest.StyleStructure
{
    [TestClass]
    public class StyleStructureTest
    {
        private StyleClass CreateStyleClassForTest()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            Style style = new Style("name", specificStyle);
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            return new StyleClass("name", styleList);
        }

        private Style CreateStyleForTest()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            return new Style("name", specificStyle);
        }

        [TestMethod]
        public void CreateSpecificStyle_WithoutParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle();
        }

        [TestMethod]
        public void CreateSpecificStyle_WithParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
        }

        [TestMethod]
        public void CreateStyle_WithoutParameters_Ok()
        {
            Style style = new Style();
        }

        [TestMethod]
        public void CreateStyle_WithParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            Style style = new Style("name", specificStyle);
        }

        [TestMethod]
        public void CreateStyleClass_WithoutParameters_Ok()
        {
            StyleClass styleClass = new StyleClass();
        }

        [TestMethod]
        public void CreateStyleClass_WithParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            Style style = new Style("name", specificStyle);
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            StyleClass styleClass = new StyleClass("name", styleList);
        }

        [TestMethod]
        public void AddStyleToStyleClass_ExpectedParameters_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            Style style = CreateStyleForTest();
            styleClass.AddStyle(style);
            Assert.IsTrue(styleClass.Styles.Contains(style));
        }

        [TestMethod]
        public void RemoveStyleFromStyleClass_ExpectedParameters_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            Style style = CreateStyleForTest();
            styleClass.AddStyle(style);
            styleClass.RemoveStyle(style);
            Assert.IsFalse(styleClass.Styles.Contains(style));
        }
    }
}

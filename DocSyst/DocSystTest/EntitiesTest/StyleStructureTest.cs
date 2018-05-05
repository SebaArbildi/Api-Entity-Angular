using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;
using System.Collections.Generic;

namespace DocSystTest.EntitiesTest.StyleStructure
{
    [TestClass]
    public class StyleStructureTest
    {
        private Format CreateFormatForTest()
        {
            return new Format("FormatName");
        }

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

        [TestMethod]
        public void AddStyleToStyleClass_AlreadyExists_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            int originalCount = styleClass.Styles.Count;
            Style style = CreateStyleForTest();
            styleClass.AddStyle(style);
            styleClass.AddStyle(style);
            Assert.IsTrue(styleClass.Styles.Count == (originalCount + 1));
        }

        [TestMethod]
        public void RemoveStyleFromStyleClass_NotExist_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            int originalCount = styleClass.Styles.Count;
            Style style = CreateStyleForTest();
            styleClass.RemoveStyle(style);
            Assert.IsTrue(styleClass.Styles.Count == originalCount);
        }

        [TestMethod]
        public void CreateStyleClass_WithParameters2_Ok()
        {
            IList<Style> styleList = new List<Style>();
            StyleClass inheritedStyleClass = CreateStyleClassForTest();

            StyleClass styleClass = new StyleClass("name", styleList, inheritedStyleClass);
        }

        [TestMethod]
        public void CreateStyleClass_WithParameters3_Ok()
        {
            StyleClass inheritedStyleClass = CreateStyleClassForTest();

            StyleClass styleClass = new StyleClass("name", inheritedStyleClass);
        }

        [TestMethod]
        public void CreateFormat_WithoutParameters_Ok()
        {
            Format format = new Format();
            Assert.IsNotNull(format);
        }

        [TestMethod]
        public void AddStyleClassToFormat_ExpectedParameters_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            Format format = CreateFormatForTest;
            format.AddStyleClass(styleClass);
            Assert.IsTrue(format.StyleClasses.Contains(styleClass));
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_ExpectedParameters_Ok()
        {
            StyleClass styleClass = CreateStyleClassForTest();
            Format format = CreateFormatForTest;
            format.RemoveStyleClass(styleClass);
            Assert.IsFalse(format.StyleClasses.Contains(styleClass));
        }

        [TestMethod]
        public void AddStyleClassToFormat_AlreadyExists_Ok()
        {
            Format format = CreateFormatForTest;
            int originalCount = styleClass.Styles.Count;
            StyleClass styleClass = CreateStyleClassForTest();

            format.AddStyleClass(styleClass);
            format.AddStyleClass(styleClass);     

            Assert.IsTrue(format.StyleClasses.Count == originalCount + 1);
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_NotExist_Ok()
        {
            Format format = CreateFormatForTest;
            int originalCount = styleClass.Styles.Count;
            StyleClass styleClass = CreateStyleClassForTest();

            format.RemoveStyleClass(styleClass);

            Assert.IsTrue(format.StyleClasses.Count == originalCount);
        }

        [TestMethod]
        public void CreateFormat_WithParameters2_Ok()
        {
            FormatException format = new Format("Name")
            Assert.IsNotNull(format);
        }

        [TestMethod]
        public void CreateFormat_WithParameters3_Ok()
        {
            IList<StyleClass> styleClassList = new List<StyleClass>();
            FormatException format = new Format("Name", styleClassList)
            Assert.IsNotNull(format);
        }
    }
}

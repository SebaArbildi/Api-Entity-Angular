﻿using System;
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

        [TestMethod]
        public void AddStyleToStyleClass_ExpectedParameters_Ok()
        {
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            Style style = Utils.CreateStyleForTest();
            styleClass.AddStyle(style);
            Assert.IsTrue(styleClass.ProperStyles.Contains(style));
        }

        [TestMethod]
        public void RemoveStyleFromStyleClass_ExpectedParameters_Ok()
        {
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            Style style = Utils.CreateStyleForTest();
            styleClass.AddStyle(style);
            styleClass.RemoveStyle(style);
            Assert.IsFalse(styleClass.ProperStyles.Contains(style));
        }

        [TestMethod]
        public void AddStyleToStyleClass_AlreadyExists_Ok()
        {
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            int originalCount = styleClass.ProperStyles.Count;
            Style style = Utils.CreateStyleForTest();
            style.Name = "newStyle";
            styleClass.AddStyle(style);
            styleClass.AddStyle(style);
            Assert.IsTrue(styleClass.ProperStyles.Count == (originalCount + 1));
        }

        [TestMethod]
        public void RemoveStyleFromStyleClass_NotExist_Ok()
        {
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            int originalCount = styleClass.ProperStyles.Count;
            Style style = Utils.CreateStyleForTest();
            style.Name = "newStyle";
            styleClass.RemoveStyle(style);
            Assert.IsTrue(styleClass.ProperStyles.Count == originalCount);
        }

        [TestMethod]
        public void CreateStyleClass_WithParameters2_Ok()
        {
            IList<Style> styleList = new List<Style>();
            StyleClass inheritedStyleClass = Utils.CreateStyleClassForTest();

            StyleClass styleClass = new StyleClass("name", styleList, inheritedStyleClass);
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
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            Format format = CreateFormatForTest();
            format.AddStyleClass(styleClass);
            Assert.IsTrue(format.StyleClasses.Contains(styleClass));
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_ExpectedParameters_Ok()
        {
            StyleClass styleClass = Utils.CreateStyleClassForTest();
            Format format = CreateFormatForTest();
            format.RemoveStyleClass(styleClass);
            Assert.IsFalse(format.StyleClasses.Contains(styleClass));
        }

        [TestMethod]
        public void AddStyleClassToFormat_AlreadyExists_Ok()
        {
            Format format = CreateFormatForTest();
            int originalCount = format.StyleClasses.Count;
            StyleClass styleClass = Utils.CreateStyleClassForTest();

            format.AddStyleClass(styleClass);
            format.AddStyleClass(styleClass);     

            Assert.IsTrue(format.StyleClasses.Count == originalCount + 1);
        }

        [TestMethod]
        public void RemoveStyleClassFromFormat_NotExist_Ok()
        {
            Format format = CreateFormatForTest();
            int originalCount = format.StyleClasses.Count;
            StyleClass styleClass = Utils.CreateStyleClassForTest();

            format.RemoveStyleClass(styleClass);

            Assert.IsTrue(format.StyleClasses.Count == originalCount);
        }

        [TestMethod]
        public void CreateFormat_WithParameters2_Ok()
        {
            Format format = new Format("Name");
            Assert.IsNotNull(format);
        }

        [TestMethod]
        public void CreateFormat_WithParameters3_Ok()
        {
            IList<StyleClass> styleClassList = new List<StyleClass>();
            Format format = new Format("Name", styleClassList);
            Assert.IsNotNull(format);
        }

        [TestMethod]
        public void TryObserver_ExpectedParam_Ok()
        {
            StyleClass inheritStyleClass = Utils.CreateStyleClassForTest();
            Style colorRed = Utils.CreateStyleForTest("color red", Style.StyleType.COLOR, "red");
            IList<Style> styleList = new List<Style>();
            styleList.Add(colorRed);
            StyleClass newStyleClass = new StyleClass("name", styleList, inheritStyleClass);


            Style alignRight = Utils.CreateStyleForTest("align right", Style.StyleType.ALIGN, "right");
            inheritStyleClass.AddStyle(alignRight);
            Assert.IsTrue(newStyleClass.InheritedPlusProperStyles.Count == 2);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.Generator;
using DocSystEntities.StyleStructure;
using DocSystEntities.DocumentStructure;
using System.Collections.Generic;

namespace DocSystTest.EntitiesTest
{
    [TestClass]
    public class GeneratorTest
    {

        private StyleClass CreateStyleClassForTest(String name, Style style)
        {
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            return new StyleClass(name, styleList, null);
        }

        private Format CreateFormatForTest(StyleClass styleClass)
        {
            IList<StyleClass> styleClasses = new List<StyleClass>();
            styleClasses.Add(styleClass);
            return new Format("FormatName", styleClasses);
        }

        [TestMethod]
        public void GenerateHTML_StyleClasInFormatOnlyOneText_Ok()
        {
            IGenerator htmlGenerator = new HtmlGenerator();
            Style colorRed = Utils.CreateStyleForTest("color red", Style.StyleType.COLOR, "red");
            Style colorBlue = Utils.CreateStyleForTest("color blue", Style.StyleType.COLOR, "blue");
            Style alignRight = Utils.CreateStyleForTest("align right", Style.StyleType.ALIGN, "right");
            Style bold = Utils.CreateStyleForTest("bold", Style.StyleType.BOLD, "bold");
            Style italic = Utils.CreateStyleForTest("italic", Style.StyleType.ITALIC, "italic");
            StyleClass styleClassInheritedParagraph = CreateStyleClassForTest("Normal0", alignRight);
            StyleClass styleClassParagraph = CreateStyleClassForTest("Normal", colorBlue);
            StyleClass styleClassDocument = CreateStyleClassForTest("Normal2", bold);

            styleClassParagraph.SetInheritedStyleClass(styleClassInheritedParagraph);
            styleClassInheritedParagraph.AddStyle(italic);

            Format format = CreateFormatForTest(styleClassParagraph);
            format.AddStyleClass(styleClassDocument);

            Document document = Utils.CreateDocumentForTest();
            Paragraph paragraph = Utils.CreateParagraphForTest();
            Text text = Utils.CreateTextForTest();
            paragraph.PutTextAtLast(text);
            document.DocumentParagraphs.Add(paragraph);

            document.OwnStyleClass = "Normal";
            paragraph.OwnStyleClass = "Normal2";

            string htmlGenerated = htmlGenerator.Generate(document, format);
            int x = 2;
        }
    }
}

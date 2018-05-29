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
        private Style CreateStyleForTest(string name, Style.StyleType type, string value)
        {
            return new StyleHtml(name, type, value);
        }

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
            Style colorRed = CreateStyleForTest("color red", Style.StyleType.COLOR, "red");
            Style colorBlue = CreateStyleForTest("color blue", Style.StyleType.COLOR, "blue");
            Style alignLeft = CreateStyleForTest("align left", Style.StyleType.ALIGN, "left");
            StyleClass styleClassParagraph = CreateStyleClassForTest("Normal", colorRed);
            StyleClass styleClassDocument = CreateStyleClassForTest("Normal2", colorBlue);
            Format format = CreateFormatForTest(styleClassParagraph);
            format.AddStyleClass(styleClassDocument);

            Document document = Utils.CreateDocumentForTest();
            Paragraph paragraph = Utils.CreateParagraphForTest();
            Text text = Utils.CreateTextForTest();
            paragraph.PutTextAtLast(text);
            document.DocumentParts.Add(paragraph);

            document.OwnStyleClass = "Normal";
            paragraph.OwnStyleClass = "Normal2";

            string htmlGenerated = htmlGenerator.Generate(document, format);
            int x = 2;
        }
    }
}

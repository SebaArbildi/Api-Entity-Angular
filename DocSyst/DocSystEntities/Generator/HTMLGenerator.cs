using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using DocSystEntities.DocumentStructure;
using DocSystEntities.StyleStructure;

namespace DocSystEntities.Generator
{
    public class HtmlGenerator : IGenerator
    {
        public string Generate(Document document, Format format)
        {
            StringBuilder htmlGenerated = new StringBuilder("<html>");
            StyleClass styleClassDocument = format.GetStyleClass(document.OwnStyleClass);
            Margin header = document.GetDocumentMargin(MarginAlign.HEADER);
            Margin footer = document.GetDocumentMargin(MarginAlign.FOOTER);
            List<Paragraph> paragraphs = document.DocumentParagraphs;

            if(header != null && header.HasText())
            {
                Text headerText = header.GetText();
                StyleClass styleClassHeader = GetStyleClassForDocumentPart(header.OwnStyleClass, format, styleClassDocument);
                StyleClass styleClassText = GetStyleClassForDocumentPart(headerText.OwnStyleClass, format, styleClassHeader);
                htmlGenerated.Append(ApplyStyleClassToText(headerText.TextContent, styleClassText));
            }

            foreach (Paragraph paragraph in paragraphs)
            {
                StyleClass styleClassBody = GetStyleClassForDocumentPart(paragraph.OwnStyleClass, format, styleClassDocument);

                foreach(Text text in paragraph.Texts)
                {
                    StyleClass styleClassText = GetStyleClassForDocumentPart(text.OwnStyleClass, format, styleClassBody);
                    htmlGenerated.Append(ApplyStyleClassToText(text.TextContent, styleClassText));
                }
            }

            if (footer != null && footer.HasText())
            {
                Text footerText = footer.GetText();
                StyleClass styleClassFooter = GetStyleClassForDocumentPart(footer.OwnStyleClass, format, styleClassDocument);
                StyleClass styleClassText = GetStyleClassForDocumentPart(footerText.OwnStyleClass, format, styleClassFooter);
                htmlGenerated.Append(ApplyStyleClassToText(footerText.TextContent, styleClassText));
            }

            htmlGenerated.Append("</html>");

            return htmlGenerated.ToString();
        }

        private StyleClass GetStyleClassForDocumentPart(string ownStyleClassName, Format format, StyleClass styleClassInherited)
        {
            StyleClass styleClassForDocumentPart = styleClassInherited;
            StyleClass ownStyleClass = format.GetStyleClass(ownStyleClassName);
            if (ownStyleClass != null)
            {
                ownStyleClass.SetInheritedStyleClass(styleClassInherited);
                styleClassForDocumentPart = ownStyleClass;
            }
            return styleClassForDocumentPart;
        }

        private string ApplyStyleClassToText(string textContent, StyleClass styleClassText)
        {
            bool hasBold = false;
            bool hasItalic = false;
            string textWithStyleClass = "";
            if (styleClassText != null)
            {
                textWithStyleClass += "<p style= '";
                foreach (Style style in styleClassText.InheritedPlusProperStyles)
                {
                    if (style.Type.Equals(Style.StyleType.BOLD))
                    {
                        hasBold = true;
                    }else if (style.Type.Equals(Style.StyleType.ITALIC))
                    {
                        hasItalic = true;
                    }
                    else
                    {
                        textWithStyleClass += style.GetImplementation() + "; ";
                    }
                }
                textWithStyleClass += ("'> ");
                textWithStyleClass += (textContent);
                textWithStyleClass += ("</p>");
            }

            if(!textWithStyleClass.Any())
            {
                textWithStyleClass += ("'> ");
                textWithStyleClass += (textContent);
                textWithStyleClass += ("</p>");
            }

            if (hasBold)
            {
                textWithStyleClass = "<strong>" + textWithStyleClass + "</strong>";
            }

            if (hasItalic)
            {
                textWithStyleClass = "<em>" + textWithStyleClass + "</em>";
            }

            textWithStyleClass += "<br>";

            return textWithStyleClass;
        }

        
    }
}

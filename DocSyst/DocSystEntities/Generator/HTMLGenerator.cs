using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Body> documentBody = document.DocumentParts;
            foreach(Body body in documentBody)
            {
                StyleClass styleClassBody = GetStyleClassForDocumentPart(body.OwnStyleClass, format, styleClassDocument);

                foreach(Text text in body.Texts)
                {
                    StyleClass styleClassText = GetStyleClassForDocumentPart(text.OwnStyleClass, format, styleClassBody);
                    htmlGenerated.Append(ApplyStyleClassToText(text.TextContent, styleClassText));
                }
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
                ownStyleClass.InheritedStyleClass = styleClassInherited;
                styleClassForDocumentPart = ownStyleClass;
            }
            return styleClassForDocumentPart;
        }

        private string ApplyStyleClassToText(string textContent, StyleClass styleClassText)
        {
            string boolean = "";
            StringBuilder textWithStyleClass = new StringBuilder("");
            if (styleClassText != null)
            {
                textWithStyleClass.Append("<p style= \"");
                foreach (Style style in styleClassText.InheritedPlusProperStyles)
                {
                    if (style.Type.Equals(Style.StyleType.BOOL))
                    {

                    }
                    else
                    {
                        textWithStyleClass.Append(style.GetImplementation() + "; ");
                    }
                }
                textWithStyleClass.Append("\"> ");
                textWithStyleClass.Append(textContent);
                textWithStyleClass.Append("</p>");
            }
            
            return textWithStyleClass.ToString();
        }

        
    }
}

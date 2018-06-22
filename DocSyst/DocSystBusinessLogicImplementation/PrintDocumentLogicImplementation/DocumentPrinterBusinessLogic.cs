using DocSystBusinessLogicInterface.PrintDocumentLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystEntities.Generator;
using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicImplementation.PrintDocumentLogicImplementation
{
    public class DocumentPrinterBusinessLogic : IDocumentPrinterBusinessLogic
    {
        private IDocumentDataAccess DocumentDataAccess;
        private IFormatDataAccess FormatDataAccess;

        public DocumentPrinterBusinessLogic()
        {
        }

        public DocumentPrinterBusinessLogic(IDocumentDataAccess aDocumentDataAccess, IFormatDataAccess aformatDataAccess)
        {
            DocumentDataAccess = aDocumentDataAccess;
            FormatDataAccess = aformatDataAccess;
        }

        public string GenerateHTML(Guid document, Guid format)
        {
            if (!DocumentDataAccess.Exists(document))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "document");
            }

            if (!FormatDataAccess.Exists(format))
            {
                throw new ArgumentException("The format argument not exist in database."
                    , "format");
            }

            HtmlGenerator Printer = new HtmlGenerator();

            Document doc = DocumentDataAccess.Get(document);
            Format form = FormatDataAccess.Get(format);

            return Printer.Generate(doc, form);
        }
    }
}

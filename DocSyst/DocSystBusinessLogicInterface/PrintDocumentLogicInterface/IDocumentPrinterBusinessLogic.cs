using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicInterface.PrintDocumentLogicInterface
{
    public interface IDocumentPrinterBusinessLogic
    {
        string GenerateHTML(Guid document, Guid format);
    }
}

using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.PrintDocumentLogicInterface;
using DocSystWebApi.Models.RerportModels;
using System;
using System.Linq;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class DocumentPrinterController : ApiController
    {
        private IDocumentPrinterBusinessLogic DocumentPrinterBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public DocumentPrinterController(IDocumentPrinterBusinessLogic documentPrinterBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            DocumentPrinterBusinessLogic = documentPrinterBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        [Route("api/PrintDocumentHtml", Name = "PrintDocument")]
        [HttpPost]
        public IHttpActionResult Get([FromBody] PrinterModel printer)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var userToken = Request.Headers.GetValues("Username").FirstOrDefault();
                var printedDocument = DocumentPrinterBusinessLogic.GenerateHTML(printer.documentId, printer.formatId);
                return Ok(printedDocument);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

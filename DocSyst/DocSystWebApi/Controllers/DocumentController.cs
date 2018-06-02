using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystEntities.Audit;
using DocSystEntities.DocumentStructure;
using DocSystWebApi.Models.DocumentStructureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class DocumentController : ApiController
    {
        private IDocumentBusinessLogic DocumentBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }
        private IAuditLogBussinesLogic AuditLogBussinesLogic { get; set; }

        public DocumentController(IDocumentBusinessLogic documentBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic
            , IAuditLogBussinesLogic auditLogBussinesLogic)
        {
            DocumentBusinessLogic = documentBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
            AuditLogBussinesLogic = auditLogBussinesLogic;
        }

        // GET: api/Document
        [Route("api/Document", Name = "GetDocuments")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var userToken = Request.Headers.GetValues("Username").FirstOrDefault();
                var documents = DocumentBusinessLogic.GetDocuments(userToken);
                IList<DocumentModel> documentsModel = DocumentModel.ToModel(documents).ToList();
                return Ok(documentsModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Document/5
        [Route("api/Document/{id:guid}", Name = "GetDocument")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var document = DocumentBusinessLogic.GetDocument(id);
                return Ok(DocumentModel.ToModel(document));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Document
        [Route("api/Document", Name = "PostDocuments")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]DocumentModel documentModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                DocumentBusinessLogic.AddDocument(documentModel.ToEntity());
                AuditLogBussinesLogic.CreateLog("Document", documentModel.Id, Utils.GetUsername(Request), ActionPerformed.CREATE);
                return Ok(documentModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Document
        [Route("api/Document/{id:guid}", Name = "PutDocument")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]DocumentModel documentModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);

                documentModel.Id = id;

                DocumentBusinessLogic.ModifyDocument(documentModel.ToEntity());
                AuditLogBussinesLogic.CreateLog("Document", documentModel.Id, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Document Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Document/5
        [Route("api/Document/{id:guid}", Name = "DeleteDocument")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                DocumentBusinessLogic.DeleteDocument(id);
                AuditLogBussinesLogic.CreateLog("Document", id, Utils.GetUsername(Request), ActionPerformed.DELETE);
                return Ok("Document deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[Route("api/Document/{documentId:guid}/Part/{align}", Name = "GetDocumentPart")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid documentId, [FromUri] MarginAlign align)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var documentPart = DocumentBusinessLogic.GetDocumentPart(documentId, align);
                return Ok(BodyModel.ToModel(documentPart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [Route("api/Document/{documentId:guid}/Part/{align}", Name = "SetDocumentPart")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] Guid documentId, [FromUri] MarginAlign align, [FromBody] BodyModel documentPart)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);

                var body = documentPart.ToEntity();
                DocumentBusinessLogic.SetDocumentPart(documentId, align, body);

                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok(documentPart);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

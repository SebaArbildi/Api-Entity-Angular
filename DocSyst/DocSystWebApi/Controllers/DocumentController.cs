using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
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

        public DocumentController(IDocumentBusinessLogic documentBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            DocumentBusinessLogic = documentBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/Document
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var userToken = Request.Headers.GetValues("UserToken").FirstOrDefault();
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
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var document = DocumentBusinessLogic.GetDocument(id);
                return Ok(DocumentModel.ToModel(document));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Document
        public IHttpActionResult Post([FromBody]DocumentModel documentModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                DocumentBusinessLogic.AddDocument(documentModel.ToEntity());
                return CreatedAtRoute("DefaultApi", new { documentModel.Id }, documentModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Document
        public IHttpActionResult Put([FromBody]DocumentModel documentModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                DocumentBusinessLogic.ModifyDocument(documentModel.ToEntity());
                return Ok("Document Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Document/5
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                DocumentBusinessLogic.DeleteDocument(id);
                return Ok("Document deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Document/{documentId:guid}/Part/{align:MarginAlign}", Name = "GetDocumentPart")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid documentId, [FromUri] MarginAlign align)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var documentPart = DocumentBusinessLogic.GetDocumentPart(documentId, align);
                return Ok(BodyModel.ToModel(documentPart));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Document/{documentId:guid}/Part/{align:MarginAlign}", Name = "SetDocumentPart")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] Guid documentId, [FromUri] MarginAlign align, [FromBody] BodyModel documentPart)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);

                var body = documentPart.ToEntity();
                DocumentBusinessLogic.SetDocumentPart(documentId, align, body);
                    
                return Ok(documentPart);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

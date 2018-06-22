using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystEntities.Audit;
using DocSystWebApi.Models.DocumentStructureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class ParagraphController : ApiController
    {
        private IParagraphBusinessLogic ParagraphBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }
        private IAuditLogBussinesLogic AuditLogBussinesLogic { get; set; }

        public ParagraphController(IParagraphBusinessLogic paragraphBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic
                                    , IAuditLogBussinesLogic auditLogBussinesLogic)
        {
            ParagraphBusinessLogic = paragraphBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
            AuditLogBussinesLogic = auditLogBussinesLogic;
        }

        // GET: api/Paragraph
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var paragraphs = ParagraphBusinessLogic.GetParagraphs();
                IList<ParagraphModel> paragraphsModel = ParagraphModel.ToModel(paragraphs).ToList();
                return Ok(paragraphsModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Paragraph/5
        [Route("api/Paragraph/{paragraphId:guid}", Name = "GetParagraph")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid paragraphId)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var paragraph = ParagraphBusinessLogic.GetParagraph(paragraphId);
                return Ok(ParagraphModel.ToModel(paragraph));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Paragraph
        public IHttpActionResult Post([FromBody]ParagraphModel paragraphModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.AddParagraph(paragraphModel.ToEntity());
                return Ok(paragraphModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}", Name = "PutParagraph")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid paragraphId, [FromBody]ParagraphModel paragraphModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);

                paragraphModel.Id = paragraphId;

                ParagraphBusinessLogic.ModifyParagraph(paragraphModel.ToEntity());

                AuditLogBussinesLogic.CreateLog("Document", paragraphModel.DocumentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Paragraph Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Paragraph/5
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid documentId = ParagraphBusinessLogic.GetParagraph(id).DocumentId.Value;
                ParagraphBusinessLogic.DeleteParagraph(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Paragraph deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text", Name = "ClearTextsParagraph")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid documentId = ParagraphBusinessLogic.GetParagraph(id).DocumentId.Value;
                ParagraphBusinessLogic.ClearText(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok("Texts clear");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text/{position:int}", Name = "GetTextAt")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid paragraphId, [FromUri] int position)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var texts = ParagraphBusinessLogic.GetTextAt(paragraphId, position);
                return Ok(TextModel.ToModel(texts));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text", Name = "PostTextAtLast")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] Guid paragraphId, [FromBody] TextModel textModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var text = TextModel.ToEntity(textModel);
                Guid documentId = ParagraphBusinessLogic.GetParagraph(paragraphId).DocumentId.Value;
                ParagraphBusinessLogic.PutTextAtLast(paragraphId, text);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok(textModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text/{position:int}", Name ="PostTextAt")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] Guid paragraphId, [FromBody] TextModel textModel, [FromUri] int position)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var text = TextModel.ToEntity(textModel);
                Guid documentId = ParagraphBusinessLogic.GetParagraph(paragraphId).DocumentId.Value;
                ParagraphBusinessLogic.PutTextAt(paragraphId, text, position);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok("Text deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text/{newPosition:int}", Name = "MoveTextTo")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid paragraphId, [FromBody] Guid textId, [FromUri] int newPosition)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid documentId = ParagraphBusinessLogic.GetParagraph(paragraphId).DocumentId.Value;
                ParagraphBusinessLogic.MoveTextTo(paragraphId, textId, newPosition);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok("Text moved to " + newPosition);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

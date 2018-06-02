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
    public class TextController : ApiController
    {
        private ITextBusinessLogic TextBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }
        private IAuditLogBussinesLogic AuditLogBussinesLogic { get; set; }

        public TextController(ITextBusinessLogic textBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic
                                , IAuditLogBussinesLogic auditLogBussinesLogic)
        {
            TextBusinessLogic = textBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
            AuditLogBussinesLogic = auditLogBussinesLogic;
        }

        // GET: api/Text
        [Route("api/Text", Name = "GetTexts")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var texts = TextBusinessLogic.GetTexts();
                IList<TextModel> textsModel = TextModel.ToModel(texts).ToList();
                return Ok(textsModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Text/5
        [Route("api/Text/{id:guid}", Name = "GetText")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var text = TextBusinessLogic.GetText(id);
                return Ok(TextModel.ToModel(text));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Text
        [Route("api/Text", Name = "PostText")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]TextModel textModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                TextBusinessLogic.AddText(textModel.ToEntity());
                return Ok(textModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Text
        [Route("api/Text/{id:guid}", Name = "PutText")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]TextModel textModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);

                textModel.Id = id;

                TextBusinessLogic.ModifyText(textModel.ToEntity());
                Guid? documentId = TextBusinessLogic.GetDocumentId(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Text Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Text/5
        [Route("api/Text/{id:guid}", Name = "DeleteText")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid? documentId = TextBusinessLogic.GetDocumentId(id);
                TextBusinessLogic.DeleteText(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Text deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

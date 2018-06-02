using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystEntities.Audit;
using DocSystWebApi.Models.DocumentStructureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class MarginController : ApiController
    {
        private IMarginBusinessLogic MarginBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }
        private IAuditLogBussinesLogic AuditLogBussinesLogic { get; set; }

        public MarginController(IMarginBusinessLogic marginBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic
                                , IAuditLogBussinesLogic auditLogBussinesLogic)
        {
            MarginBusinessLogic = marginBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
            AuditLogBussinesLogic = auditLogBussinesLogic;
        }

        // GET: api/Margin
        [Route("api/Margin", Name = "GetMargins")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var margins = MarginBusinessLogic.GetMargins();
                IList<MarginModel> marginsModel = MarginModel.ToModel(margins).ToList();
                return Ok(marginsModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Margin/5
        [Route("api/Margin/{id:guid}", Name = "GetMargin")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var margin = MarginBusinessLogic.GetMargin(id);
                return Ok(MarginModel.ToModel(margin));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Margin
        [Route("api/Margin", Name = "PostMargin")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]MarginModel marginModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                MarginBusinessLogic.AddMargin(marginModel.ToEntity());
                return Ok(marginModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Margin
        [Route("api/Margin/{id:guid}", Name = "PutMargin")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]MarginModel marginModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);

                marginModel.Id = id;

                MarginBusinessLogic.ModifyMargin(marginModel.ToEntity());
                AuditLogBussinesLogic.CreateLog("Document", marginModel.DocumentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok(marginModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Margin/5
        [Route("api/Margin/{id:guid}", Name = "DeleteMargin")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid documentId = MarginBusinessLogic.GetMargin(id).DocumentId.Value;
                MarginBusinessLogic.DeleteMargin(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Margin deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Margin/{marginId:guid}/SetText", Name = "PostTextInMargin")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid marginId, [FromBody] TextModel textModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                var text = TextModel.ToEntity(textModel);
                Guid documentId = MarginBusinessLogic.GetMargin(marginId).DocumentId.Value;
                MarginBusinessLogic.SetText(marginId, text);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);

                return Ok(textModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Margin/{marginId:guid}/ClearText", Name = "ClearTextsMargin")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Guid documentId = MarginBusinessLogic.GetMargin(id).DocumentId.Value;
                MarginBusinessLogic.ClearText(id);
                AuditLogBussinesLogic.CreateLog("Document", documentId, Utils.GetUsername(Request), ActionPerformed.MODIFY);
                return Ok("Texts clear");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

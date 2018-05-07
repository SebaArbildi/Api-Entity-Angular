using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
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

        public ParagraphController(IParagraphBusinessLogic paragraphBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            ParagraphBusinessLogic = paragraphBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/Paragraph
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
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
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var paragraph = ParagraphBusinessLogic.GetParagraph(id);
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.AddParagraph(paragraphModel.ToEntity());
                return CreatedAtRoute("DefaultApi", new { paragraphModel.Id }, paragraphModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Paragraph
        public IHttpActionResult Put([FromBody]ParagraphModel paragraphModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.ModifyParagraph(paragraphModel.ToEntity());
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.DeleteParagraph(id);
                return Ok("Paragraph deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Paragraph/{paragraphId:guid}/Text", Name = "ClearTexts")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.ClearText(id);
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var text = TextModel.ToEntity(textModel);
                ParagraphBusinessLogic.PutTextAtLast(paragraphId, text);
                return CreatedAtRoute("DefaultApi", new { textModel.Id }, textModel);
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var text = TextModel.ToEntity(textModel);
                ParagraphBusinessLogic.PutTextAt(paragraphId, text, position);
                return CreatedAtRoute("DefaultApi", new { textModel.Id }, textModel);
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
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                ParagraphBusinessLogic.MoveTextTo(paragraphId, textId, newPosition);
                return Ok("Text moved to " + newPosition);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

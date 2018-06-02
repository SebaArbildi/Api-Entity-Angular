using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using DocSystEntities.StyleStructure;
using DocSystWebApi.Models.StyleStructureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class FormatController : ApiController
    {
        private IFormatBusinessLogic FormatBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public FormatController(IFormatBusinessLogic formatBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            FormatBusinessLogic = formatBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }
        // GET: api/Format
        [Route("api/Format", Name = "GetFormats")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                IList<Format> formats = FormatBusinessLogic.Get();
                IList<FormatModel> formatsModels = Utils.ConvertEntitiesToModels(formats);
                return Ok(formatsModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Format/5
        [Route("api/Format/{id:guid}", Name = "GetFormat")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                Format format = FormatBusinessLogic.Get(id);
                return Ok(FormatModel.ToModel(format));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Format
        [Route("api/Format", Name = "PostFormat")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]FormatModel formatModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                FormatBusinessLogic.Add(formatModel.ToEntity());
                return Ok(formatModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Format/5
        [Route("api/Format/{id:guid}", Name = "PutFormat")]
        [HttpPut]
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]FormatModel formatModel)
        {
            try
            {
                formatModel.Id = id;
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                FormatBusinessLogic.Modify(formatModel.ToEntity());
                return Ok("Format Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Format/5
        [Route("api/Format/{id:guid}", Name = "DeleteFormat")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                FormatBusinessLogic.Delete(id);
                return Ok("Format deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Format", Name = "AddStyleClassToFormat")]
        [HttpPut]
        public IHttpActionResult AddStyleClassToFormat([FromUri] Guid formatId, [FromBody]StyleClassModel styleClassModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                FormatBusinessLogic.AddStyle(formatId, styleClassModel.ToEntity());
                return Ok("Style Class added to Format");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Format", Name = "RemoveStyleClassFromFormat")]
        [HttpPut]
        public IHttpActionResult RemoveStyleClassFromFormat([FromUri] Guid formatId, [FromBody] Guid styleClassId
            )
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                FormatBusinessLogic.RemoveStyle(formatId, styleClassId);
                return Ok("Style Class removed from Format");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

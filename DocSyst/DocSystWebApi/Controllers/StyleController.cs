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
    public class StyleController : ApiController
    {
        private IStyleBusinessLogic StyleBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public StyleController(IStyleBusinessLogic styleBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            StyleBusinessLogic = styleBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }
        // GET: api/Style
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                IList<Style> styles = StyleBusinessLogic.Get();
                IList<StyleModel> stylesModels = Utils.ConvertEntitiesToModels(styles);
                return Ok(stylesModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Style/5
        public IHttpActionResult Get([FromUri]string name)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                Style style = StyleBusinessLogic.Get(name);
                return Ok(StyleModel.ToModel(style));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Style
        public IHttpActionResult Post([FromBody]StyleModel styleModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleBusinessLogic.Add(styleModel.ToEntity());
                return Ok("Style added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT: api/Style/5
        public IHttpActionResult Put([FromUri] string name, [FromBody]StyleModel styleModel)
        {
            try
            {
                styleModel.Name = name;
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleBusinessLogic.Modify(styleModel.ToEntity());
                return Ok("Style Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/Style/5
        public IHttpActionResult Delete([FromUri] String name)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleBusinessLogic.Delete(name);
                return Ok("Style deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

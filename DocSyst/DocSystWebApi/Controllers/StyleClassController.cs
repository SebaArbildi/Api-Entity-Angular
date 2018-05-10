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
    public class StyleClassController : ApiController
    {
        private IStyleClassBusinessLogic StyleClassBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public StyleClassController(IStyleClassBusinessLogic styleClassBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            StyleClassBusinessLogic = styleClassBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/StyleClass
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                IList<StyleClass> styleClasses = StyleClassBusinessLogic.Get();
                IList<StyleClassModel> styleClassesModels = Utils.ConvertEntitiesToModels(styleClasses);
                return Ok(styleClassesModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/StyleClass/5
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClass styleClass = StyleClassBusinessLogic.Get(id);
                return Ok(StyleClassModel.ToModel(styleClass));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/StyleClass
        public IHttpActionResult Post([FromBody]StyleClassModel styleClassModel)
        {
//try
//{
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClassBusinessLogic.Add(styleClassModel.ToEntity());
                return Ok("Style Class added");
           // }
            /*catch (Exception e)
            {
                return BadRequest(e.Message);
            }*/
        }

        // PUT: api/StyleClass/5
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]StyleClassModel styleClassModel)
        {
            try
            {
                styleClassModel.Id = id;
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClassBusinessLogic.Modify(styleClassModel.ToEntity());
                return Ok("Style Class Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/StyleClass/5
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClassBusinessLogic.Delete(id);
                return Ok("Style Class deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/StyleClass", Name = "AddStyleToStyleClass")]
        [HttpPut]
        public IHttpActionResult AddStyleToStyleClass([FromUri] Guid styleClassId, [FromBody]StyleModel styleModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClassBusinessLogic.AddStyle(styleClassId, styleModel.ToEntity());
                return Ok("Style added to Style Class");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/StyleClass", Name = "RemoveStyleFromStyleClass")]
        [HttpPut]
        public IHttpActionResult RemoveStyleFromStyleClass([FromUri] Guid styleClassId, [FromBody]string styleName)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                StyleClassBusinessLogic.RemoveStyle(styleClassId, styleName);
                return Ok("Style removed from Style Class");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}

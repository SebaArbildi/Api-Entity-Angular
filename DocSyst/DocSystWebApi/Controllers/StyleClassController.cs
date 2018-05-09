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
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                SpecificStyleBusinessLogic.Add(specificStyleModel.ToEntity());
                return Ok("Specific Style added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/StyleClass/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StyleClass/5
        public void Delete(int id)
        {
        }
    }
}

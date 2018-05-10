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
    public class SpecificStyleController : ApiController
    {
        private ISpecificStyleBusinessLogic SpecificStyleBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public SpecificStyleController(ISpecificStyleBusinessLogic specificStyleBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            SpecificStyleBusinessLogic = specificStyleBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        // GET: api/SpecificStyle
        public IHttpActionResult Get()
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                IList<SpecificStyle> specificStyles = SpecificStyleBusinessLogic.Get();
                IList<SpecificStyleModel> specificStylesModels = ConvertEntitiesToModels(specificStyles);
                return Ok(specificStylesModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/SpecificStyle/5
        public IHttpActionResult Get([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                SpecificStyle specificStyle = SpecificStyleBusinessLogic.Get(id);
                return Ok(SpecificStyleModel.ToModel(specificStyle));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/SpecificStyle
        public IHttpActionResult Post([FromBody]SpecificStyleModel specificStyleModel)
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

        // PUT: api/SpecificStyle/5
        public IHttpActionResult Put([FromUri] Guid id, [FromBody]SpecificStyleModel specificStyleModel)
        {
            try
            {
                specificStyleModel.Id = id;
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                SpecificStyleBusinessLogic.Modify(specificStyleModel.ToEntity());
                return Ok("Specific Style Modified");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/SpecificStyle/5
        public IHttpActionResult Delete([FromUri] Guid id)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                SpecificStyleBusinessLogic.Delete(id);
                return Ok("Specific Style deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private IList<SpecificStyleModel> ConvertEntitiesToModels(IList<SpecificStyle> specificStyles)
        {
            IList<SpecificStyleModel> specificStylesModels = new List<SpecificStyleModel>();
            foreach (SpecificStyle specificStyle in specificStyles)
            {
                specificStylesModels.Add(SpecificStyleModel.ToModel(specificStyle));
            }
            return specificStylesModels;
        }
    }
}

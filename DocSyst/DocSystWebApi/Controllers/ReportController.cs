using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystWebApi.Models.RerportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocSystWebApi.Controllers
{
    public class ReportController : ApiController
    {
        private IAuditLogBussinesLogic AuditLogBusinessLogic { get; set; }
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public ReportController(IAuditLogBussinesLogic auditLogBusinessLogic, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            AuditLogBusinessLogic = auditLogBusinessLogic;
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        [Route("api/Reports/EntitiesForAnActionByUserBetweenDates", Name = "GetEntitiesForAnActionByUserBetweenDates")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] DocumentsCreatedPerUserBetweenDates reportModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var report = AuditLogBusinessLogic
                    .GetLogsPerUserForAnAction(reportModel.UsersId, reportModel.FromDate, reportModel.ToDate, reportModel.EntityType, reportModel.Action);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/Reports/EntitiesByUserPerDayBetweenDates", Name = "GetEntitiesByUserPerDayBetweenDates")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] DocumentsActionedPerUserPerDayBetweenDates reportModel)
        {
            try
            {
                Utils.IsAValidToken(Request, AuthorizationBusinessLogic);
                Utils.HasAdminPermissions(Request, AuthorizationBusinessLogic);
                var report = AuditLogBusinessLogic
                    .GetLogsPerUserPerDay(reportModel.UsersId, reportModel.FromDate, reportModel.ToDate, reportModel.EntityType);
                return Ok(report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

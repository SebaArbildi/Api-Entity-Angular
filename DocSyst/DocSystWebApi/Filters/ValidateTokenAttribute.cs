using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DocSystWebApi.Filters
{
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        public ValidateTokenAttribute(IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            this.AuthorizationBusinessLogic = authorizationBusinessLogic;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool isAuthorized = false;
            Guid token = Guid.Empty;
            var headers = actionContext.Request.Headers;

            if (headers.Contains("Token"))
            {
                token = Guid.Parse(headers.GetValues("Token").First());
                isAuthorized = AuthorizationBusinessLogic.IsAValidToken(token);
            }

            if (!isAuthorized)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}
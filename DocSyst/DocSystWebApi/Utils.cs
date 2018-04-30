using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DocSystWebApi
{
    internal class Utils
    {
        private IAuthorizationBusinessLogic AuthorizationBusinessLogic { get; set; }

        internal Utils(IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            AuthorizationBusinessLogic = authorizationBusinessLogic;
        }
        internal void ValidateToken(HttpRequestMessage request)
        {
            bool isAuthorized = false;
            Guid token = Guid.Empty;
            var headers = request.Headers;

            if (headers.Contains("Token"))
            {
                token = Guid.Parse(headers.GetValues("Token").First());
                isAuthorized = AuthorizationBusinessLogic.IsAValidToken(token);
            }

            if (!isAuthorized)
            {
                throw new ArgumentException("Token not valid");
            }

        }
    }
}
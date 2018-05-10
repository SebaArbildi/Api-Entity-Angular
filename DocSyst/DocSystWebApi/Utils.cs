using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DocSystWebApi
{
    internal static class Utils
    {

        private static Guid GetToken(HttpRequestMessage request)
        {
            var headers = request.Headers;

            if (headers.Contains("Token"))
            {
                return Guid.Parse(headers.GetValues("Token").First());
            }
            else
            {
                throw new ArgumentNullException("request.Headers", "Doen't contains the token");
            }
        }

        internal static bool IsAValidToken(HttpRequestMessage request, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            bool isAValidToken = false;
            Guid token = GetToken(request);

            if (authorizationBusinessLogic.IsAValidToken(token))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("Token is not valid.");
            }
        }

        internal static bool HasAdminPermissions(HttpRequestMessage request, IAuthorizationBusinessLogic authorizationBusinessLogic)
        {
            Guid token = GetToken(request);
            if (authorizationBusinessLogic.IsAdmin(token))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("User has not admin permissions");
            }
        }

        internal static string GetUsername(HttpRequestMessage request)
        {
            if (request.Headers.Contains("Username"))
            {
                return request.Headers.GetValues("Username").First();
            }
            else
            {
                throw new ArgumentNullException("request.Headers", "Doen't contains the username");
            }
        }
    }
}
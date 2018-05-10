using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystEntities.StyleStructure;
using DocSystWebApi.Models.StyleStructureModels;
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
		
		internal static IList<StyleModel> ConvertEntitiesToModels(IList<Style> styles)
        {
            IList<StyleModel> stylesModels = new List<StyleModel>();
            foreach (Style style in styles)
            {
                stylesModels.Add(StyleModel.ToModel(style));
            }
            return stylesModels;
        }


        internal static IList<Style> ConvertModelsToEntities(IList<StyleModel> stylesModel)
        {
            IList<Style> styles = new List<Style>();
            foreach (StyleModel styleModel in stylesModel)
            {
                styles.Add(styleModel.ToEntity());
            }
            return styles;
        }

        internal static IList<StyleClassModel> ConvertEntitiesToModels(IList<StyleClass> styleClasses)
        {
            IList<StyleClassModel> styleClassesModels = new List<StyleClassModel>();
            foreach (StyleClass styleClass in styleClasses)
            {
                styleClassesModels.Add(StyleClassModel.ToModel(styleClass));
            }
            return styleClassesModels;
        }

        internal static IList<StyleClass> ConvertModelsToEntities(IList<StyleClassModel> styleClassModels)
        {
            IList<StyleClass> styleClass = new List<StyleClass>();
            foreach (StyleClassModel styleClassModel in styleClassModels)
            {
                styleClass.Add(styleClassModel.ToEntity());
            }
            return styleClass;
        }

        internal static IList<FormatModel> ConvertEntitiesToModels(IList<Format> formats)
        {
            IList<FormatModel> formatsModels = new List<FormatModel>();
            foreach (Format format in formats)
            {
                formatsModels.Add(FormatModel.ToModel(format));
            }
            return formatsModels;
        }

        internal static IList<Format> ConvertModelsToEntities(IList<FormatModel> formatsModels)
        {
            IList<Format> formats = new List<Format>();
            foreach (FormatModel formatModel in formatsModels)
            {
                formats.Add(formatModel.ToEntity());
            }
            return formats;
        }
    }
}
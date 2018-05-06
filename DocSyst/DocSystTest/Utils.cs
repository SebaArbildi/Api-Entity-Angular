using DocSystDataAccessImplementation;
using DocSystEntities.StyleStructure;
using DocSystEntities.User;
using System;
using System.Collections.Generic;

namespace DocSystTest
{
    internal static class Utils
    {

        private static Random random = new Random();
        internal static void DeleteBd()
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Database.Delete();
            }
        }

        internal static User CreateUserForTest()
        {          
            return new User("Name", "LastName", random.Next().ToString(), "Password", "Mail", true);
        }

        internal static StyleClass CreateStyleClassForTest()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            Style style = new Style("name", specificStyle);
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            return new StyleClass("name", styleList, null);
        }

        internal static Style CreateStyleForTest()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            return new Style("name", specificStyle);
        }

        internal static SpecificStyle CreateSpecificStyleForTest()
        {
            return new SpecificStyle("name", "<html><body>{0}</body></html>");
        }
    }
}

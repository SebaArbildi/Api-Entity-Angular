using DocSystDataAccessImplementation;
using DocSystDataAccessImplementation.StyleStructureDataAccess;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
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
            Style style = CreateStyleForTest();
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            return new StyleClass("name", styleList, null);
        }

        internal static Style CreateStyleForTest()
        {
            ISpecificStyleDataAccess specificStyleDataAccess = new SpecificStyleDataAccess();
            SpecificStyle specificStyle = CreateSpecificStyleForTest("name");
            specificStyleDataAccess.Add(specificStyle);
            return new Style("name", specificStyle);
        }

        internal static SpecificStyle CreateSpecificStyleForTest(String name)
        {
            return new SpecificStyle(name, "<html><body>{0}</body></html>");
        }

        internal static SpecificStyle CreateSpecificStyleInDataBaseForTest(String name)
        {
            ISpecificStyleDataAccess specificStyleDataAccess = new SpecificStyleDataAccess();
            SpecificStyle specificStyle = CreateSpecificStyleForTest(name);
            specificStyleDataAccess.Add(specificStyle);
            return specificStyle;
        }
    }
}

using DocSystDataAccessImplementation;
using DocSystEntities.Audit;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System;

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

        internal static Text CreateTextForTest()
        {
            return new Text("a Text content","a Style Class");
        }

        internal static Paragraph CreateParagraphForTest()
        {
            return new Paragraph(MarginAlign.PARAGRAPH,"a Style Class");
        }

        internal static Margin CreateMarginForTest()
        {
            return new Margin(MarginAlign.FOOTER,"a Style Class");
        }

        internal static Document CreateDocumentForTest()
        {
            return new Document("a Title","a Style Class",CreateUserForTest());
        }

        internal static AuditLog CreateAuditLogForTest()
        {
            return new AuditLog();
        }
		
		internal static StyleClass CreateStyleClassForTest()
        {
            Style style = CreateStyleInDataBaseForTest();
            IList<Style> styleList = new List<Style>();
            styleList.Add(style);
            return new StyleClass("name", styleList, null);
        }

        internal static StyleClass CreateStyleClassInDataBaseForTest()
        {
            IStyleClassDataAccess styleClassDataAccess = new StyleClassDataAccess();
            StyleClass styleClass = CreateStyleClassForTest();
            styleClassDataAccess.Add(styleClass);
            return styleClass;
        }

        internal static Style CreateStyleForTest()
        {
            SpecificStyle specificStyle = CreateSpecificStyleInDataBaseForTest("Name");
            return new Style("name", specificStyle);
        }

        internal static Style CreateStyleInDataBaseForTest()
        {
            IStyleDataAccess styleDataAccess = new StyleDataAccess();
            Style style = CreateStyleForTest();
            styleDataAccess.Add(style);
            return style;
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

        internal static Format CreateFormatForTest()
        {
            StyleClass styleClass = CreateStyleClassInDataBaseForTest();
            IList<StyleClass> styleClasses = new List<StyleClass>();
            styleClasses.Add(styleClass);
            return new Format("FormatName", styleClasses);
        }
    }
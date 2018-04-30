using DocSystDataAccessImplementation;
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
            return new Document("a Title","a Style Class");
        }
    }
}
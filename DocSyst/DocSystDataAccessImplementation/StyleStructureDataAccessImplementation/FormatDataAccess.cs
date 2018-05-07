using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessImplementation.StyleStructureDataAccessImplementation
{
    public class FormatDataAccess : IFormatDataAccess
    {
        private static String STYLE_CLASSES = "StyleClasses";
        public void Add(Format format)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachStyleClassList(context, format.StyleClasses);
                context.Formats.Add(format);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            Format format = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachStyleClassList(context, format.StyleClasses);
                context.Formats.Attach(format);
                context.Formats.Remove(format);
                context.SaveChanges();
            }
        }

        public IList<Format> Get()
        {
            IList<Format> formats = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                formats = context.Formats.Include(STYLE_CLASSES).ToList<Format>();
            }
            return formats;
        }

        public Format Get(Guid id)
        {
            Format format = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                format = context.Formats.Include(STYLE_CLASSES).Where(formatDb => formatDb.Id == id).FirstOrDefault();
            }
            return format;
        }

        public void Modify(Format format)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachStyleClassList(context, format.StyleClasses);
                Format actualFormat = context.Formats.Include(STYLE_CLASSES).Where(formatDb => formatDb.Id == format.Id).FirstOrDefault();
                context.Entry(actualFormat).Entity.StyleClasses = format.StyleClasses;
                context.Entry(actualFormat).CurrentValues.SetValues(actualFormat);
                context.SaveChanges();
            }
        }

        private void AttachStyleClassList(DocSystDbContext context, IList<StyleClass> styleClasses)
        {
            foreach(StyleClass styleClass in styleClasses)
            {
                context.StyleClasses.Attach(styleClass);
            }
        }
    }
}

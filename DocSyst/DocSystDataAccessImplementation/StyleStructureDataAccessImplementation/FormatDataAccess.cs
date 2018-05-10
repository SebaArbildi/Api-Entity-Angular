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
                IList<StyleClass> stClass = AttachStyleClassList(context, format.StyleClasses);
                format.StyleClasses = stClass;
                context.Formats.Add(format);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            Format format = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                IList<StyleClass> stClass = AttachStyleClassList(context, format.StyleClasses);
                format.StyleClasses = stClass;
                context.Formats.Attach(format);
                context.Formats.Remove(format);
                context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Formats.Any(formatDb => formatDb.Id == id);
            }
            return exists;
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
                IList<StyleClass> stClass = AttachStyleClassList(context, format.StyleClasses);
                format.StyleClasses = stClass;
                Format actualFormat = context.Formats.Include(STYLE_CLASSES).Where(formatDb => formatDb.Id == format.Id).FirstOrDefault();
                context.Entry(actualFormat).Entity.StyleClasses = format.StyleClasses;
                context.Entry(actualFormat).CurrentValues.SetValues(actualFormat);
                context.SaveChanges();
            }
        }

        private IList<StyleClass> AttachStyleClassList(DocSystDbContext context, IList<StyleClass> styleClasses)
        {
            IList<StyleClass> styles = new List<StyleClass>();

            foreach (StyleClass styleClass in styleClasses)
            {
                StyleClass stClass = context.StyleClasses.Include("ProperStyles").Include("InheritedStyleClass")
                    .Include("InheritedPlusProperStyles").Include("Observers").Where(styleClassDb => styleClassDb.Id == styleClass.Id).FirstOrDefault();
                context.StyleClasses.Attach(stClass);
                styles.Add(stClass);
            }
            return styles;
        }
    }
}

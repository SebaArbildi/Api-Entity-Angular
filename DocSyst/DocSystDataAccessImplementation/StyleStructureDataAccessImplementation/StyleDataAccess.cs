using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessImplementation.StyleStructureDataAccessImplementation
{
    public class StyleDataAccess : IStyleDataAccess
    {
        public void Add(Style style)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.SpecificStyles.Attach(style.Implementation);
                context.Styles.Add(style);
                context.SaveChanges();
            }
        }

        public void Delete(string name)
        {
            Style style = Get(name);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Styles.Attach(style);
                context.Styles.Remove(style);
                context.SaveChanges();
            }
        }

        public IList<Style> Get()
        {
            IList<Style> styles = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                styles = context.Styles.Include("Implementation").ToList<Style>();
            }
            return styles;
        }

        public Style Get(string name)
        {
            Style style = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                style = context.Styles.Include("Implementation").Where(styleDb => styleDb.Name == name).FirstOrDefault();
            }
            return style;
        }

        public void Modify(Style style)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.SpecificStyles.Attach(style.Implementation);
                Style actualStyle = context.Styles.Include("Implementation").Where(styleDb => styleDb.Name == styleDb.Name).FirstOrDefault();
                context.Entry(actualStyle).Entity.Implementation = style.Implementation;
                context.Entry(actualStyle).CurrentValues.SetValues(style);
                context.SaveChanges();
            }
        }
    }
}

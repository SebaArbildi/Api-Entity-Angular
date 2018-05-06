using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessImplementation.StyleStructureDataAccess
{
    public class SpecificStyleDataAccess : ISpecificStyleDataAccess
    {
        public void Add(SpecificStyle specificStyle)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.SpecificStyles.Add(specificStyle);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            SpecificStyle specificStyle = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.SpecificStyles.Attach(specificStyle);
                context.SpecificStyles.Remove(specificStyle);
                context.SaveChanges();
            }
        }

        public IList<SpecificStyle> Get()
        {
            IList<SpecificStyle> specificStyles = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                specificStyles = context.SpecificStyles.ToList<SpecificStyle>();
            }
            return specificStyles;
        }

        public SpecificStyle Get(Guid id)
        {
            SpecificStyle specificStyle = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                specificStyle = context.SpecificStyles.Where(specificStyleDb => specificStyleDb.Id == id).FirstOrDefault();
            }
            return specificStyle;
        }

        public void Modify(SpecificStyle specificStyle)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                SpecificStyle actualSpecificStyle = context.SpecificStyles.Where(specificStyleDb => specificStyleDb.Id == specificStyle.Id).FirstOrDefault();
                context.Entry(actualSpecificStyle).CurrentValues.SetValues(specificStyle);
                context.SaveChanges();
            }
        }
    }
}

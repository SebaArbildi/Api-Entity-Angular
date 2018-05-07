using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;
using DocSystEntities.ObserverInterface;

namespace DocSystDataAccessImplementation.StyleStructureDataAccessImplementation
{
    public class StyleClassDataAccess : IStyleClassDataAccess
    {
        private static String PROPER_STYLES = "ProperStyles";
        private static String INHERITED_STYLE_CLASS = "InheritedStyleClass";
        private static String INHERITED_PLUS_PROPER_STYLES = "InheritedPlusProperStyles";
        private static String OBSERVERS = "Observers";

        public void Add(StyleClass styleClass)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachInheritedStyleClass(context, styleClass.InheritedStyleClass);
                AttachStyleList(context, styleClass.ProperStyles);
                AttachObserverList(context, styleClass.Observers);
                context.StyleClasses.Add(styleClass);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            StyleClass styleClass = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachInheritedStyleClass(context, styleClass.InheritedStyleClass);
                AttachStyleList(context, styleClass.ProperStyles);
                AttachObserverList(context, styleClass.Observers);
                context.StyleClasses.Attach(styleClass);
                context.StyleClasses.Remove(styleClass);
                context.SaveChanges();
            }
        }

        public IList<StyleClass> Get()
        {
            IList<StyleClass> styleClasses = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                styleClasses = context.StyleClasses.Include(PROPER_STYLES).Include(INHERITED_STYLE_CLASS)
                    .Include(INHERITED_PLUS_PROPER_STYLES).Include(OBSERVERS).ToList<StyleClass>();
            }
            return styleClasses;
        }

        public StyleClass Get(Guid id)
        {
            StyleClass styleClass = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                styleClass = context.StyleClasses.Include("ProperStyles").Include("InheritedStyleClass")
                    .Include("InheritedPlusProperStyles").Include("Observers").Where(styleClassDb => styleClassDb.Id == id).FirstOrDefault();
            }
            return styleClass;
        }

        public void Modify(StyleClass styleClass)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AttachInheritedStyleClass(context, styleClass.InheritedStyleClass);
                AttachStyleList(context, styleClass.ProperStyles);
                AttachObserverList(context, styleClass.Observers);
                StyleClass actualStyleClass = context.StyleClasses.Include("ProperStyles").Include("InheritedStyleClass")
                    .Include("InheritedPlusProperStyles").Include("Observers").Where(styleClassDb => styleClassDb.Id == styleClass.Id).FirstOrDefault();

                context.Entry(actualStyleClass).Entity.InheritedPlusProperStyles = styleClass.InheritedPlusProperStyles;
                context.Entry(actualStyleClass).Entity.InheritedStyleClass = styleClass.InheritedStyleClass;
                context.Entry(actualStyleClass).Entity.Observers = styleClass.Observers;
                context.Entry(actualStyleClass).Entity.ProperStyles = styleClass.ProperStyles;
                context.Entry(actualStyleClass).CurrentValues.SetValues(styleClass);
                context.SaveChanges();
            }
        }

        private void AttachStyleList(DocSystDbContext context, IList<Style> styleList)
        {
            foreach (Style style in styleList)
            {
                context.Styles.Attach(style);
            }
        }

        private void AttachObserverList(DocSystDbContext context, IList<StyleClass> observerList)
        {
            foreach (StyleClass observer in observerList)
            {
                context.StyleClasses.Attach(observer);
            }
        }

        private void AttachInheritedStyleClass(DocSystDbContext context, StyleClass inehritedStyleClass)
        {
            if(inehritedStyleClass != null)
            {
                context.StyleClasses.Attach(inehritedStyleClass);
            }
        }
    }
}

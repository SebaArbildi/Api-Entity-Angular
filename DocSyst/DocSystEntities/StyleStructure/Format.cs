using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class Format
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<StyleClass> StyleClasses { get; set; }

        public Format()
        {
            this.Id = Guid.NewGuid();
            this.StyleClasses = new List<StyleClass>();
        }

        public Format(string name, IList<StyleClass> styleClasses)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.StyleClasses = styleClasses;
        }

        public Format(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.StyleClasses = new List<StyleClass>();
        }

        public void AddStyleClass(StyleClass styleClass)
        {
            if (!StyleClasses.Contains(styleClass))
            {
                StyleClasses.Add(styleClass);
            }
        }

        public void RemoveStyleClass(StyleClass styleClass)
        {
            if (StyleClasses.Contains(styleClass))
            {
                StyleClasses.Remove(styleClass);
            }
        }

        public StyleClass GetStyleClass(string name)
        {
            StyleClass styleClass = null;
            foreach(StyleClass styleC in this.StyleClasses)
            {
                if (styleC.Name.Equals(name))
                {
                    styleClass = styleC;
                    break;
                }
            }
            return styleClass;
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            Format format = (Format)obj;
            if (this.Id.Equals(format.Id))
            {
                equals = true;
            }
            return equals;
        }
    }
}

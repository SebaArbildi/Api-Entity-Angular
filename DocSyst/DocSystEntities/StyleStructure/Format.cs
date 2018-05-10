using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class Format
    {
        private Guid id;
        private string name;
        private IList<StyleClass> styleClasses;

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

        public Guid Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public IList<StyleClass> StyleClasses
        {
            get
            {
                return styleClasses;
            }

            set
            {
                styleClasses = value;
            }
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

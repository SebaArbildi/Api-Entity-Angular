using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class StyleClass
    {
        private Guid id;
        private string name;
        private IList<Style> styles;
        private StyleClass inheritedStyleClass;

        public StyleClass()
        {
            this.Id = Guid.NewGuid();
            this.Styles = new List<Style>();
        }

        public StyleClass(string name, IList<Style> styles)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Styles = styles;
        }

        public StyleClass(string name, IList<Style> styles, StyleClass inherited)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Styles = styles;
            this.inheritedStyleClass = inherited;
        }

        public StyleClass(string name, StyleClass inherited)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Styles = new List<Style>();
            this.inheritedStyleClass = inherited;
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

        public IList<Style> Styles
        {
            get
            {
                return styles;
            }

            set
            {
                styles = value;
            }
        }

        public StyleClass InheritedStyleClass
        {
            get
            {
                return inheritedStyleClass;
            }

            set
            {
                inheritedStyleClass = value;
            }
        }

        public void AddStyle(Style style)
        {
            if (!Styles.Contains(style))
            {
                Styles.Add(style);
            }
        }

        public void RemoveStyle(Style style)
        {
            if (Styles.Contains(style))
            {
                Styles.Remove(style);
            }
        }
    }
}

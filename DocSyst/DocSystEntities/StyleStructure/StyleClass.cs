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

        public StyleClass() { }

        public StyleClass(string name, IList<Style> styles)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Styles = styles;
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

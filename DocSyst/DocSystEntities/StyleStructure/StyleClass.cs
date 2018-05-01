using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class StyleClass
    {
        private string name;
        private IList<Style> styles;

        public StyleClass() { }

        public StyleClass(string name, IList<Style> styles)
        {
            this.Name = name;
            this.Styles = styles;
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
    }
}

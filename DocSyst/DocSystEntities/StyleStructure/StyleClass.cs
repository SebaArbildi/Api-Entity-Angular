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
        private Style style;

        public StyleClass() { }

        public StyleClass(string name, Style style)
        {
            this.Name = name;
            this.Style = style;
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

        public Style Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }
    }
}

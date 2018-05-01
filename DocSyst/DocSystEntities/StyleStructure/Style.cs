using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class Style
    {
        private string name;
        private SpecificStyle implementation;

        public Style() { }

        public Style(string name, SpecificStyle implementation)
        {
            this.Name = name;
            this.Implementation = implementation;
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

        public SpecificStyle Implementation
        {
            get
            {
                return implementation;
            }

            set
            {
                implementation = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class SpecificStyle
    {
        private Guid id;
        private string name;
        private string implementation;

        public SpecificStyle() { }

        public SpecificStyle(string name, string implementation)
        {
            this.Name = name;
            this.Implementation = implementation;
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

        public string Implementation
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

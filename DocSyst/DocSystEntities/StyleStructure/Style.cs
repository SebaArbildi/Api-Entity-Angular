using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class Style
    {
        private Guid id;
        private string name;
        private SpecificStyle implementation;

        public Style()
        {
            this.Id = Guid.NewGuid();
        }

        public Style(string name, SpecificStyle implementation)
        {
            this.Id = Guid.NewGuid();
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
    }
}

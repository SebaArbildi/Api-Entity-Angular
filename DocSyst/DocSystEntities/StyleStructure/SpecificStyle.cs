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

        public SpecificStyle()
        {
            this.Id = Guid.NewGuid();
        }

        public SpecificStyle(string name, string implementation)
        {
            Id = Guid.NewGuid();
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

        public override bool Equals(object obj)
        {
            bool equals = false;
            SpecificStyle specificStyle = (SpecificStyle)obj;
            if (this.Id.Equals(specificStyle.Id))
            {
                equals = true;
            }
            return equals;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public class StyleHtml : Style
    {
        public StyleHtml()
        {
        }

        public StyleHtml(string name, StyleType type, string implementation)
        {
            this.Name = name;
            this.Type = type;
            this.Implementation = implementation;
        }

        public override string GetImplementation()
        {
            throw new NotImplementedException();
        }
    }
}

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
            this.Id = Guid.NewGuid();
        }

        public StyleHtml(string name, StyleType type, string value)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }

        public override string GetImplementation()
        {
            string implementation = "";
            if (this.Type.Equals(StyleType.ALIGN))
            {
                implementation = "text-align: " + Value;
            }
            else if (this.Type.Equals(StyleType.COLOR))
            {
                implementation = "color: " + Value;
            }
            else if (this.Type.Equals(StyleType.DECORATION))
            {
                implementation = "text-decoration: " + Value;
            }
            else if (this.Type.Equals(StyleType.FONT))
            {
                implementation = "font-family: " + Value;
            }
            else if (this.Type.Equals(StyleType.BORDER))
            {
                implementation = "border: " + Value;
            }

            return implementation;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.StyleStructure
{
    public abstract class Style
    {
        public enum StyleType
        {
            ALIGN, FONT, COLOR, DECORATION, BOLD, ITALIC, BORDER
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public StyleType Type { get; set; }
        public string Value { get; set; }

        public abstract string GetImplementation();

        public override bool Equals(object obj)
        {
            bool equals = false;
            Style style = (Style)obj;
            if (this.Type.Equals(style.Type))
            {
                equals = true;
            }
            return equals;
        }
    }
}

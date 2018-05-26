using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.StyleStructureModels
{
    public class StyleModel : Model<Style, StyleModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public StyleModel() { }

        public StyleModel(Style style)
        {
            SetModel(style);
        }

        public override Style ToEntity() => new StyleHtml()
        {
            Id = this.Id,
            Name = this.Name,
        };

        protected override StyleModel SetModel(Style style)
        {
            Id = style.Id;
            Name = style.Name;
            return this;
        }

        public override bool Equals(object obj)
        {
            var style = obj as StyleModel;
            if (style == null)
                return false;
            return this.Name == style.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
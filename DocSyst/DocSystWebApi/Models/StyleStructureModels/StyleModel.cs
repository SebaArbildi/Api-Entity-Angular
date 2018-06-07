using DocSystEntities.StyleStructure;
using System;
using static DocSystEntities.StyleStructure.Style;

namespace DocSystWebApi.Models.StyleStructureModels
{
    public class StyleModel : Model<Style, StyleModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StyleType Type { get; set; }
        public string Value { get; set; }

        public StyleModel() { }

        public StyleModel(Style style)
        {
            SetModel(style);
        }

        public override Style ToEntity()
        {
            Style style = new StyleHtml()
            {
                Name = this.Name,
                Type = this.Type,
                Value = this.Value
            };

            if (!this.Id.Equals(Guid.Empty))
            {
                style.Id = this.Id;
            }
            else
            {
                this.Id = style.Id;
            }

            return style;
        }

        protected override StyleModel SetModel(Style style)
        {
            Id = style.Id;
            Name = style.Name;
            Type = style.Type;
            Value = style.Value;

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
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
        public SpecificStyleModel Implementation { get; set; }

        public StyleModel() { }

        public StyleModel(Style style)
        {
            SetModel(style);
        }

        public override Style ToEntity() => new Style()
        {
            Id = this.Id,
            Name = this.Name,
            Implementation = this.Implementation.ToEntity(),
        };

        protected override StyleModel SetModel(Style style)
        {
            Id = style.Id;
            Name = style.Name;
            Implementation = SpecificStyleModel.ToModel(style.Implementation);
            return this;
        }

        public override bool Equals(object obj)
        {
            var specificStyle = obj as SpecificStyleModel;
            if (specificStyle == null)
                return false;
            return this.Id == specificStyle.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
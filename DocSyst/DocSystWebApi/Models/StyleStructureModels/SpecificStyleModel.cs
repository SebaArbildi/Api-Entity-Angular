using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.StyleStructureModels
{
    public class SpecificStyleModel: Model<SpecificStyle, SpecificStyleModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Implementation { get; set; }

        public SpecificStyleModel() { }

        public SpecificStyleModel(SpecificStyle specificStyle)
        {
            SetModel(specificStyle);
        }

        public override SpecificStyle ToEntity() => new SpecificStyle()
        {
            Id = this.Id,
            Name = this.Name,
            Implementation = this.Implementation
        };

        protected override SpecificStyleModel SetModel(SpecificStyle specificStyle)
        {
            Id = specificStyle.Id;
            Name = specificStyle.Name;
            Implementation = specificStyle.Implementation;
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
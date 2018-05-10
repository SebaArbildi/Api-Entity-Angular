using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.StyleStructureModels
{
    public class FormatModel : Model<Format, FormatModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private IList<StyleClassModel> StyleClasses { get; set; }

        public FormatModel() { }

        public FormatModel(Format format)
        {
            SetModel(format);
        }

        public override Format ToEntity() => new Format()
        {
            Id = this.Id,
            Name = this.Name,
            StyleClasses = Utils.ConvertModelsToEntities(this.StyleClasses),
        };

        protected override FormatModel SetModel(Format format)
        {
            Id = format.Id;
            Name = format.Name;
            StyleClasses = Utils.ConvertEntitiesToModels(format.StyleClasses);
            return this;
        }

        public override bool Equals(object obj)
        {
            var styleClass = obj as StyleClassModel;
            if (styleClass == null)
                return false;
            return this.Id == styleClass.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.StyleStructureModels
{
    public class StyleClassModel : Model<StyleClass, StyleClassModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private IList<StyleModel> ProperStyles { get; set; }
        private StyleClassModel InheritedStyleClass { get; set; }
        private IList<StyleModel> InheritedPlusProperStyles { get; set; }
        private IList<StyleClassModel> Observers { get; set; }

        public StyleClassModel() { }

        public StyleClassModel(StyleClass styleClass)
        {
            SetModel(styleClass);
        }

        public override StyleClass ToEntity()
        {
            StyleClass styleClass = new StyleClass()
            {
                Id = this.Id,
                Name = this.Name,
                ProperStyles = Utils.ConvertModelsToEntities(this.ProperStyles),
                InheritedPlusProperStyles = Utils.ConvertModelsToEntities(this.InheritedPlusProperStyles),
                Observers = Utils.ConvertModelsToEntities(this.Observers)
            };

            /*TODO: Another solution, so there is not need to handle if InheritedStyleClass is null*/
            if (this.InheritedStyleClass != null)
            {
                styleClass.InheritedStyleClass = this.InheritedStyleClass.ToEntity();
            }

            return styleClass;
        }

        protected override StyleClassModel SetModel(StyleClass styleClass)
        {
            Id = styleClass.Id;
            Name = styleClass.Name;
            ProperStyles = Utils.ConvertEntitiesToModels(styleClass.ProperStyles);
            InheritedPlusProperStyles = Utils.ConvertEntitiesToModels(styleClass.InheritedPlusProperStyles);
            Observers = Utils.ConvertEntitiesToModels(styleClass.Observers);
            if (styleClass.InheritedStyleClass != null)
            {
                InheritedStyleClass = StyleClassModel.ToModel(styleClass.InheritedStyleClass);
            }
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
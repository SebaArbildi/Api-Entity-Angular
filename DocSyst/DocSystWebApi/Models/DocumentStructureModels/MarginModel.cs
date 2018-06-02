using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class MarginModel : Model<Margin, MarginModel>
    {
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<TextModel> Texts { get; set; }
        public MarginAlign Align { get; set; }
        public Guid? DocumentId { get; set; }

        public MarginModel() { }

        public MarginModel(Margin margin)
        {
            SetModel(margin);
        }

        public override Margin ToEntity()
        {
            List<Text> texts = null;

            if(this.Texts != null)
            {
                texts = ConvertModelsToTexts(this.Texts);
            }

            Margin thisMargin = new Margin()
            {
                OwnStyleClass = this.OwnStyleClass,
                Texts = texts,
                Align = this.Align,
                DocumentId = this.DocumentId
            };

            if (!this.Id.Equals(Guid.Empty))
            {
                thisMargin.Id = this.Id;
            }
            else
            {
                this.Id = thisMargin.Id;
            }

            return thisMargin;
        }

        protected override MarginModel SetModel(Margin entity)
        {
            List<TextModel> textModels = ConvertTextsToModels(entity.Texts);

            Id = entity.Id;
            OwnStyleClass = entity.OwnStyleClass;
            Texts = textModels;
            Align = entity.Align;
            DocumentId = entity.DocumentId;
            return this;
        }

        private List<TextModel> ConvertTextsToModels(List<Text> texts)
        {
            return TextModel.ToModel(texts).ToList();
        }

        private List<Text> ConvertModelsToTexts(List<TextModel> textModels)
        {
            return TextModel.ToEntity(textModels).ToList();
        }

        public override bool Equals(object obj)
        {
            var otherMargin = obj as MarginModel;
            if (otherMargin == null)
                return false;
            return this.Id == otherMargin.Id;
        }
    }
}
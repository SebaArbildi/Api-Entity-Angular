using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class ParagraphModel : Model<Paragraph, ParagraphModel>
    {
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<TextModel> Texts { get; set; }
        [Required]
        public MarginAlign Align { get; set; }
        public Guid? DocumentId { get; set; }

        public ParagraphModel() { }

        public ParagraphModel(Paragraph paragraph)
        {
            SetModel(paragraph);
        }

        public override Paragraph ToEntity()
        {
            List<Text> texts = ConvertModelsToTexts(this.Texts);

            Paragraph thisParagraph = new Paragraph()
            {
                OwnStyleClass = this.OwnStyleClass,
                Texts = texts,
                Align = this.Align,
                DocumentId = this.DocumentId
            };

            if (!this.Id.Equals(Guid.Empty))
            {
                thisParagraph.Id = this.Id;
            }
            else
            {
                this.Id = thisParagraph.Id;
            }

            return thisParagraph;
        }

        protected override ParagraphModel SetModel(Paragraph entity)
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
            var otherParagraph = obj as ParagraphModel;
            if (otherParagraph == null)
                return false;
            return this.Id == otherParagraph.Id;
        }
    }
}
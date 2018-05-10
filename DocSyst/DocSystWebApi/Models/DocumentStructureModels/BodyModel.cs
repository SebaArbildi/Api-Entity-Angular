using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class BodyModel : Model<Body, BodyModel>
    {
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<TextModel> Texts { get; set; }
        [Required]
        public MarginAlign Align { get; set; }
        public Guid DocumentId { get; set; }

        public BodyModel() { }

        public BodyModel(Body body)
        {
            SetModel(body);
        }

        public override Body ToEntity()
        {
            List<Text> texts = ConvertModelsToTexts(this.Texts);
            Body thisBody;

            if(IsMargin())
            {
                thisBody = CreateMargin(texts);
            }
            else
            {
                thisBody = CreateParagraph(texts);
            }

            this.Id = thisBody.Id;
            return thisBody;
        }

        protected override BodyModel SetModel(Body entity)
        {
            List<TextModel> textModels = ConvertTextsToModels(entity.Texts);

            Id = entity.Id;
            OwnStyleClass = entity.OwnStyleClass;
            Texts = textModels;
            Align = entity.Align;
            DocumentId = entity.DocumentId;
            return this;
        }

        private Margin CreateMargin(List<Text> texts)
        {
            Margin thisMargin = new Margin()
            {
                OwnStyleClass = this.OwnStyleClass,
                Texts = texts,
                Align = this.Align,
                DocumentId = this.DocumentId
            };

            return thisMargin;
        }

        private Paragraph CreateParagraph(List<Text> texts)
        {
            Paragraph thisParagraph = new Paragraph()
            {
                OwnStyleClass = this.OwnStyleClass,
                Texts = texts,
                Align = this.Align,
                DocumentId = this.DocumentId
            };

            return thisParagraph;
        }

        private bool IsParagraph()
        {
            return Align == MarginAlign.PARAGRAPH;
        }

        private bool IsMargin()
        {
            return Align == MarginAlign.HEADER || Align == MarginAlign.FOOTER;
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
            var otherBody = obj as BodyModel;
            if (otherBody == null)
                return false;
            return this.Id == otherBody.Id;
        }
    }
}
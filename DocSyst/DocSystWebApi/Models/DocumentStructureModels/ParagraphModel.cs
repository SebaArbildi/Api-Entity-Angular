using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class ParagraphModel : Model<Paragraph, ParagraphModel>
    {
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Text> Texts { get; set; }
        [Required]
        public MarginAlign? Align { get; set; }
        public Guid? DocumentId { get; set; }

        public ParagraphModel() { }

        public ParagraphModel(Paragraph paragraph)
        {
            SetModel(paragraph);
        }

        public override Paragraph ToEntity() => new Paragraph()
        {
            Id = this.Id,
            OwnStyleClass = this.OwnStyleClass,
            Texts = this.Texts,
            Align = this.Align,
            DocumentId = this.DocumentId
        };

        protected override ParagraphModel SetModel(Paragraph entity)
        {
            Id = entity.Id;
            OwnStyleClass = entity.OwnStyleClass;
            Texts = entity.Texts;
            Align = entity.Align;
            DocumentId = entity.DocumentId;
            return this;
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
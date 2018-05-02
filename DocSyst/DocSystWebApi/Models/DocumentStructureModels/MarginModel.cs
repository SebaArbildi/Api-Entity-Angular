using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class MarginModel : Model<Margin, MarginModel>
    {
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Text> Texts { get; set; }
        [Required]
        public MarginAlign? Align { get; set; }
        public Guid? DocumentId { get; set; }

        public MarginModel() { }

        public MarginModel(Margin margin)
        {
            SetModel(margin);
        }

        public override Margin ToEntity() => new Margin()
        {
            Id = this.Id,
            OwnStyleClass = this.OwnStyleClass,
            Texts = this.Texts,
            Align = this.Align,
            DocumentId = this.DocumentId
        };

        protected override MarginModel SetModel(Margin entity)
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
            var otherMargin = obj as MarginModel;
            if (otherMargin == null)
                return false;
            return this.Id == otherMargin.Id;
        }
    }
}
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class TextModel : Model<Text, TextModel>
    {
        public Guid Id { get; set; }
        public string TextContent { get; set; }
        public string OwnStyleClass { get; set; }
        public Guid? BodyId { get; set; }

        public TextModel() { }

        public TextModel(Text text)
        {
            SetModel(text);
        }

        public override Text ToEntity()
        {
            Text aText = new Text()
            {
                TextContent = this.TextContent,
                OwnStyleClass = this.OwnStyleClass,
                BodyId = this.BodyId
            };

            this.Id = aText.Id;
            return aText;
        }

        protected override TextModel SetModel(Text entity)
        {
            Id = entity.Id;
            TextContent = entity.TextContent;
            OwnStyleClass = entity.OwnStyleClass;
            BodyId = entity.BodyId;
            return this;
        }

        public override bool Equals(object obj)
        {
            var otherText = obj as TextModel;
            if (otherText == null)
                return false;
            return this.Id == otherText.Id;
        }
    }
}
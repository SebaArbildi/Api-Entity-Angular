using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class DocumentModel : Model<Document, DocumentModel>
    {
        public Guid Id { get; set; }
        [Required]
        public User CreatorUser { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Body> DocumentParts { get; set; }

        public DocumentModel() { }

        public DocumentModel(Document document)
        {
            SetModel(document);
        }

        public override Document ToEntity() => new Document()
        {
            Id = this.Id,
            CreatorUser = this.CreatorUser,
            Title = this.Title,
            CreationDate = this.CreationDate,
            LastModifyDate = this.LastModifyDate,
            OwnStyleClass = this.OwnStyleClass,
            DocumentParts = this.DocumentParts
        };

        protected override DocumentModel SetModel(Document entity)
        {
            Id = entity.Id;
            CreatorUser = entity.CreatorUser;
            Title = entity.Title;
            CreationDate = entity.CreationDate;
            LastModifyDate = entity.LastModifyDate;
            OwnStyleClass = entity.OwnStyleClass;
            DocumentParts = entity.DocumentParts;
            return this;
        }

        public override bool Equals(object obj)
        {
            var otherDocument = obj as DocumentModel;
            if (otherDocument == null)
                return false;
            return this.Id == otherDocument.Id;
        }
    }
}
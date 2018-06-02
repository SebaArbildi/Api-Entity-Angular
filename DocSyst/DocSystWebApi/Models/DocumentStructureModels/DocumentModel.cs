using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DocSystWebApi.Models.DocumentStructureModels
{
    public class DocumentModel : Model<Document, DocumentModel>
    {
        public Guid Id { get; set; }
        public UserModel.UserModel CreatorUser { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string OwnStyleClass { get; set; }
        public List<MarginModel> DocumentMargins { get; set; }
        public List<ParagraphModel> DocumentParagraphs { get; set; }

        public DocumentModel() { }

        public DocumentModel(Document document)
        {
            SetModel(document);
        }

        public override Document ToEntity()
        {
            
            List<Margin> margins = ConvertModelsToBodys(this.DocumentMargins);
            List<Paragraph> paragraphs = ConvertModelsToParagraphs(this.DocumentParagraphs);

            User user = null;
            if (this.CreatorUser != null)
            {
                user = ConvertModelToUser(this.CreatorUser);
            }

            Document doc = new Document()
            {
                CreatorUser = user,
                Title = this.Title,
                CreationDate = this.CreationDate,
                LastModifyDate = this.LastModifyDate,
                OwnStyleClass = this.OwnStyleClass,
                DocumentMargins = margins,
                DocumentParagraphs = paragraphs
            };

            if(!this.Id.Equals(Guid.Empty))
            {
                doc.Id = this.Id;
            }
            else
            {
                this.Id = doc.Id;
            }

            return doc;
        }

        protected override DocumentModel SetModel(Document entity)
        {
            List<MarginModel> documentMargins = ConvertBodysToModels(entity.DocumentMargins);
            List<ParagraphModel> documentParagraphs = ConvertParagraphsToModels(entity.DocumentParagraphs);
            UserModel.UserModel userModel = ConvertUserToModel(entity.CreatorUser);

            Id = entity.Id;
            CreatorUser = userModel;
            Title = entity.Title;
            CreationDate = entity.CreationDate;
            LastModifyDate = entity.LastModifyDate;
            OwnStyleClass = entity.OwnStyleClass;
            DocumentMargins = documentMargins;
            DocumentParagraphs = documentParagraphs;
            return this;
        }

        private User ConvertModelToUser(UserModel.UserModel userModel)
        {
            return userModel.ToEntity();
        }

        private UserModel.UserModel ConvertUserToModel(User user)
        {
            return new UserModel.UserModel(user);
        }

        private List<MarginModel> ConvertBodysToModels(List<Margin> bodys)
        {
            return MarginModel.ToModel(bodys).ToList();
        }

        private List<ParagraphModel> ConvertParagraphsToModels(List<Paragraph> paragraphs)
        {
            return ParagraphModel.ToModel(paragraphs).ToList();
        }

        private List<Margin> ConvertModelsToBodys(List<MarginModel> bodyModels)
        {
            return MarginModel.ToEntity(bodyModels).ToList();
        }

        private List<Paragraph> ConvertModelsToParagraphs(List<ParagraphModel> paragraphModels)
        {
            return ParagraphModel.ToEntity(paragraphModels).ToList();
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
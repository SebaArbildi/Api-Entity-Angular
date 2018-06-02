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
        public List<BodyModel> DocumentParts { get; set; }

        public DocumentModel() { }

        public DocumentModel(Document document)
        {
            SetModel(document);
        }

        public override Document ToEntity()
        {
            List<Body> bodys = null;

            if (this.DocumentParts != null)
            {
                bodys = ConvertModelsToBodys(this.DocumentParts);
            }

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
                DocumentParts = bodys
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
            List<BodyModel> documentParts = ConvertBodysToModels(entity.DocumentParts);
            UserModel.UserModel userModel = ConvertUserToModel(entity.CreatorUser);

            Id = entity.Id;
            CreatorUser = userModel;
            Title = entity.Title;
            CreationDate = entity.CreationDate;
            LastModifyDate = entity.LastModifyDate;
            OwnStyleClass = entity.OwnStyleClass;
            DocumentParts = documentParts;
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

        private List<BodyModel> ConvertBodysToModels(List<Body> bodys)
        {
            return BodyModel.ToModel(bodys).ToList();
        }

        private List<Body> ConvertModelsToBodys(List<BodyModel> bodyModels)
        {
            return BodyModel.ToEntity(bodyModels).ToList();
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
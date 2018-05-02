using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocSystEntities.DocumentStructure
{
    public enum MarginAlign
    {
        HEADER,
        FOOTER,
        PARAGRAPH,
    }

    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public User.User CreatorUser { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; }
        public DateTime LastModifyDate { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Body> DocumentParts { get; set; }

        public Document()
        {
            Id = Guid.NewGuid();
            CreatorUser = null;
            Title = null;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle, List<Body> someDocumentParts, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = someDocumentParts;
        }

        public Document(string aTitle, List<Body> someDocumentParts, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentParts = someDocumentParts;
        }

        public Body GetDocumentPart(MarginAlign align)
        {
            if (!ExistDocumentPart(align))
            {
                throw new KeyNotFoundException();
            }

            return DocumentParts.Find(x => x.Align == align);
        }

        public void SetDocumentPart(MarginAlign? align, Body aDocumentPart)
        {
            if (ExistDocumentPart(align))
            {
                DocumentParts.Remove(DocumentParts.Find(x => x.Align == align));
            }

            //aDocumentPart.FatherDocument = this;
            aDocumentPart.DocumentId = this.Id;
            DocumentParts.Add(aDocumentPart);
        }

        public bool ExistDocumentPart(MarginAlign? align)
        {
            return DocumentParts.Exists(x => x.Align == align);
        }

        public string GetCreatorUsername()
        {
            return CreatorUser.Username;
        }

        public override bool Equals(object obj)
        {
            return Id == ((Document)obj).Id;
        }
    }
}

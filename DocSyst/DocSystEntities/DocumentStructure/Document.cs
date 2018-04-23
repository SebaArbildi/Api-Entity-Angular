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
        public string Title { get; set; }
        public DateTime CreationDate { get; }
        public DateTime LastModifyDate { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Body> DocumentParts { get; set; }

        public Document()
        {
            Id = Guid.NewGuid();
            Title = null;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle)
        {
            Id = Guid.NewGuid();
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle, string aStyleClass)
        {
            Id = Guid.NewGuid();
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentParts = new List<Body>();
        }

        public Document(string aTitle, List<Body> someDocumentParts)
        {
            Id = Guid.NewGuid();
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParts = someDocumentParts;
        }

        public Document(string aTitle, List<Body> someDocumentParts, string aStyleClass)
        {
            Id = Guid.NewGuid();
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

        public void SetDocumentPart(MarginAlign align, Body aDocumentPart)
        {
            if (ExistDocumentPart(align))
            {
                DocumentParts.Remove(DocumentParts.Find(x => x.Align == align));
            }
            DocumentParts.Add(aDocumentPart);
        }

        public bool ExistDocumentPart(MarginAlign align)
        {
            return DocumentParts.Exists(x => x.Align == align);
        }

        public override bool Equals(object obj)
        {
            return Id == ((Document)obj).Id;
        }
    }
}

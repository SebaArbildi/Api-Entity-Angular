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
        public DateTime CreationDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Margin> DocumentMargins { get; set; }
        public List<Paragraph> DocumentParagraphs { get; set; }

        public Document()
        {
            Id = Guid.NewGuid();
            CreatorUser = null;
            Title = null;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentMargins = new List<Margin>();
            DocumentParagraphs = new List<Paragraph>();
        }

        public Document(string aTitle, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentMargins = new List<Margin>();
            DocumentParagraphs = new List<Paragraph>();
        }

        public Document(string aTitle, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentMargins = new List<Margin>();
            DocumentParagraphs = new List<Paragraph>();
        }

        public Document(string aTitle, List<Margin> someDocumentMargins, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentMargins = someDocumentMargins;
            DocumentParagraphs = new List<Paragraph>();
        }

        public Document(string aTitle, List<Paragraph> someDocumentParagraphs, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentParagraphs = someDocumentParagraphs;
            DocumentMargins = new List<Margin>();
        }

        public Document(string aTitle, List<Margin> someDocumentMargins, List<Paragraph> someDocumentParagraphs, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = null;
            DocumentMargins = someDocumentMargins;
            DocumentParagraphs = someDocumentParagraphs;
        }

        public Document(string aTitle, List<Margin> someDocumentParts, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentMargins = someDocumentParts;
            DocumentParagraphs = new List<Paragraph>();
        }

        public Document(string aTitle, List<Paragraph> someDocumentParagraphs, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentParagraphs = someDocumentParagraphs;
            DocumentMargins = new List<Margin>();
        }

        public Document(string aTitle, List<Margin> someDocumentParts, List<Paragraph> someDocumentParagraphs, string aStyleClass, User.User aCreatorUser)
        {
            Id = Guid.NewGuid();
            CreatorUser = aCreatorUser;
            Title = aTitle;
            CreationDate = DateTime.Today;
            LastModifyDate = DateTime.Today;
            OwnStyleClass = aStyleClass;
            DocumentMargins = someDocumentParts;
            DocumentParagraphs = someDocumentParagraphs;
        }

        public Margin GetDocumentMargin(MarginAlign align)
        {
            if (!ExistDocumentMargin(align))
            {
                return null;
            }

            return DocumentMargins.Find(x => x.Align == align);
        }

        public Paragraph GetDocumentParagraphAt(int paragraphIndex)
        {
            if (!ExistDocumentParagraphIndex(paragraphIndex))
            {
                throw new KeyNotFoundException();
            }

            return DocumentParagraphs[paragraphIndex];
        }

        public void MoveParagraphTo(int newPosition, Guid paragraphId)
        {
            Paragraph aParagraph = DocumentParagraphs.Find(x => x.Id == paragraphId);

            DocumentParagraphs.Remove(aParagraph);
            DocumentParagraphs.Insert(newPosition, aParagraph);
        }

        public void SetDocumentMargin(MarginAlign? align, Margin aDocumentMargin)
        {
            if (ExistDocumentMargin(align))
            {
                DocumentMargins.Remove(DocumentMargins.Find(x => x.Align == align));
            }

            aDocumentMargin.DocumentId = this.Id;
            DocumentMargins.Add(aDocumentMargin);
        }

        public void AddDocumentParagraphAt(Paragraph aParagraph, int index)
        {
            if (ExistDocumentParagraph(aParagraph))
            {
                throw new Exception("Paragraph already exist in document");
            }
            if (!IsIndexParagraphInRange(index))
            {
                throw new IndexOutOfRangeException();
            }

            DocumentParagraphs.Insert(index, aParagraph);
        }

        public void AddDocumentParagraphAtLast(Paragraph aParagraph)
        {
            if (ExistDocumentParagraph(aParagraph))
            {
                throw new Exception("Paragraph already exist in document");
            }

            DocumentParagraphs.Add(aParagraph);
        }

        public bool ExistDocumentMargin(MarginAlign? align)
        {
            return DocumentMargins.Exists(x => x.Align == align);
        }

        private bool IsIndexParagraphInRange(int index)
        {
            return index <= DocumentParagraphs.Count;
        }

        public bool ExistDocumentParagraphIndex(int paragraphIndex)
        {
            return DocumentParagraphs.Count > paragraphIndex;
        }

        public bool ExistDocumentParagraph(Paragraph aParagraph)
        {
            return DocumentParagraphs.Exists(x => x.Id == aParagraph.Id);
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
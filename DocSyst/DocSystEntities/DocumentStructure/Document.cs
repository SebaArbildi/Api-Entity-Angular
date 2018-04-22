using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        public Guid id { get; set; }
        public string title { get; set; }
        public DateTime creationDate { get; }
        public DateTime lastModifyDate { get; set; }
        public string ownStyleClas { get; set; }
        public List<Body> documentParts { get; set; }

        public Document()
        {
            id = Guid.NewGuid();
            title = null;
            creationDate = DateTime.Today;
            lastModifyDate = DateTime.Today;
            ownStyleClas = null;
            documentParts = new List<Body>();
        }

        public Document(string aTitle)
        {
            id = Guid.NewGuid();
            title = aTitle;
            creationDate = DateTime.Today;
            lastModifyDate = DateTime.Today;
            ownStyleClas = null;
            documentParts = new List<Body>();
        }

        public Document(string aTitle, string aStyleClass)
        {
            id = Guid.NewGuid();
            title = aTitle;
            creationDate = DateTime.Today;
            lastModifyDate = DateTime.Today;
            ownStyleClas = aStyleClass;
            documentParts = new List<Body>();
        }

        public Document(string aTitle, List<Body> someDocumentParts)
        {
            id = Guid.NewGuid();
            title = aTitle;
            creationDate = DateTime.Today;
            lastModifyDate = DateTime.Today;
            ownStyleClas = null;
            documentParts = someDocumentParts;
        }

        public Document(string aTitle, List<Body> someDocumentParts, string aStyleClass)
        {
            id = Guid.NewGuid();
            title = aTitle;
            creationDate = DateTime.Today;
            lastModifyDate = DateTime.Today;
            ownStyleClas = aStyleClass;
            documentParts = someDocumentParts;
        }

        public Body GetDocumentPart(MarginAlign align)
        {
            if (!ExistDocumentPart(align))
            {
                throw new KeyNotFoundException();
            }

            return documentParts.Find(x => x.Align == align);
        }

        public void SetDocumentPart(MarginAlign align, Body aDocumentPart)
        {
            if (ExistDocumentPart(align))
            {
                documentParts.Remove(documentParts.Find(x => x.Align == align));
            }
            documentParts.Add(aDocumentPart);
        }

        public bool ExistDocumentPart(MarginAlign align)
        {
            return documentParts.Exists(x => x.Align == align);
        }
    }
}

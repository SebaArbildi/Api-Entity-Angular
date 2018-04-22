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
        public Guid id { get; }
        public string title { get; set; }
        public DateTime creationDate { get; }
        public DateTime lastModifyDate { get; set; }
        public string ownStyleClas { get; set; }
        public List<Body> documentParts { get; }

        public Document()
        {
            
        }

        public Document(string title)
        {

        }

        public Document(string title, string aStyleClass)
        {

        }

        public Document(string title, List<Body> someDocumentParts)
        {

        }

        public Document(string title, List<Body> someDocumentParts, string aStyleClass)
        {

        }

        public Body GetDocumentPart(MarginAlign align)
        {
            throw new NotImplementedException();
        }

        public void SetDocumentPart(MarginAlign align, Body aDocumentPart)
        {
            throw new NotImplementedException();
        }

        public bool ExistDocumentPart(MarginAlign align)
        {
            throw new NotImplementedException();
        }
    }
}

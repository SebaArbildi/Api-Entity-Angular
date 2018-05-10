using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocSystEntities.DocumentStructure
{
    public class Text
    {   
        [Key]
        public Guid Id { get; set; }
        public string TextContent { get; set; }
        public string OwnStyleClass { get; set; }
        public Guid BodyId { get; set; }

        public Text()
        {
            Id = Guid.NewGuid();
            TextContent = null;
            OwnStyleClass = null;
        }

        public Text(string aTextContent)
        {
            Id = Guid.NewGuid();
            TextContent = aTextContent;
            OwnStyleClass = null;
        }

        public Text(string aTextContent, string aStyleClass)
        {
            Id = Guid.NewGuid();
            TextContent = aTextContent;
            OwnStyleClass = aStyleClass;
        }

        public bool IsEmpty()
        {
            if(TextContent == null || TextContent.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return Id == ((Text)obj).Id;
        }
    }
}

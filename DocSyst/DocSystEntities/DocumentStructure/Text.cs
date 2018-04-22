using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public class Text
    {
        public Guid id { get; set; }
        public string textContent { get; set; }
        public string ownStyleClass { get; set; }

        public Text()
        {
            id = Guid.NewGuid();
            textContent = null;
            ownStyleClass = null;
        }

        public Text(string aTextContent)
        {
            id = Guid.NewGuid();
            textContent = aTextContent;
            ownStyleClass = null;
        }

        public Text(string aTextContent, string aStyleClass)
        {
            id = Guid.NewGuid();
            textContent = aTextContent;
            ownStyleClass = aStyleClass;
        }

        public bool IsEmpty()
        {
            if(textContent == null || textContent.Length == 0)
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
            return id == ((Text)obj).id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public class Text
    {
        public Guid id { get; }
        public string textContent { get; set; }
        public string ownStyleClass { get; set; }

        public Text()
        {

        }

        public Text(String aText)
        {

        }

        public Text(String aText, string aStyleClass)
        {

        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}

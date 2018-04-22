using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public abstract class Body
    {
        public Guid id { get; }
        public string ownStyleClass { get; set; }
        public List<Text> texts { get; }
        public MarginAlign Align { get; set; }

        protected Body()
        {

        }

        protected Body(List<Text> someTexts)
        {

        }

        protected Body(List<Text> someTexts, string aStyleClass)
        {

        }

        public bool ExistText(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

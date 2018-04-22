using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public abstract class Body
    {
        public Guid id { get; set; }
        public string ownStyleClass { get; set; }
        public List<Text> texts { get; set; }
        public MarginAlign? Align { get; set; }

        protected Body()
        {
            id = Guid.NewGuid();
            ownStyleClass = null;
            texts = new List<Text>();
            Align = null;
        }

        protected Body(MarginAlign align)
        {
            id = Guid.NewGuid();
            ownStyleClass = null;
            texts = new List<Text>();
            Align = align;
        }

        protected Body(MarginAlign align, List<Text> someTexts)
        {
            id = Guid.NewGuid();
            ownStyleClass = null;
            texts = someTexts;
            Align = align;
        }

        protected Body(MarginAlign align, string aStyleClass)
        {
            id = Guid.NewGuid();
            ownStyleClass = aStyleClass;
            texts = new List<Text>();
            Align = align;
        }

        protected Body(MarginAlign align, List<Text> someTexts, string aStyleClass)
        {
            id = Guid.NewGuid();
            ownStyleClass = aStyleClass;
            texts = someTexts;
            Align = align;
        }

        public bool ExistText(Guid id)
        {
            if (texts.Exists(x => x.id == id))
            {
                return true;
            }
            return false;
        }

        public bool HasText()
        {
            return texts.Count > 0;
        }
    }
}

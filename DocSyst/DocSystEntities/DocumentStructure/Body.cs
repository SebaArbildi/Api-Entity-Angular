using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocSystEntities.DocumentStructure
{
    public abstract class Body
    {
        [Key]
        public Guid Id { get; set; }
        public string OwnStyleClass { get; set; }
        public List<Text> Texts { get; set; }
        public MarginAlign? Align { get; set; }

        protected Body()
        {
            Id = Guid.NewGuid();
            OwnStyleClass = null;
            Texts = new List<Text>();
            Align = null;
        }

        protected Body(MarginAlign align)
        {
            Id = Guid.NewGuid();
            OwnStyleClass = null;
            Texts = new List<Text>();
            Align = align;
        }

        protected Body(MarginAlign align, List<Text> someTexts)
        {
            Id = Guid.NewGuid();
            OwnStyleClass = null;
            Texts = someTexts;
            Align = align;
        }

        protected Body(MarginAlign align, string aStyleClass)
        {
            Id = Guid.NewGuid();
            OwnStyleClass = aStyleClass;
            Texts = new List<Text>();
            Align = align;
        }

        protected Body(MarginAlign align, List<Text> someTexts, string aStyleClass)
        {
            Id = Guid.NewGuid();
            OwnStyleClass = aStyleClass;
            Texts = someTexts;
            Align = align;
        }

        public bool ExistText(Guid id)
        {
            if (Texts.Exists(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool HasText()
        {
            return Texts.Count > 0;
        }

        public override bool Equals(object obj)
        {
            return Id == ((Body)obj).Id;
        }
    }
}

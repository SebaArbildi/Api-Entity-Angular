using System;
using System.Collections.Generic;

namespace DocSystEntities.DocumentStructure
{
    public class Paragraph : Body
    {
        public Paragraph() : base()
        {

        }

        public Paragraph(MarginAlign align) : base(align)
        {
        }

        public Paragraph(MarginAlign align, string aStyleClass) : base(align,aStyleClass)
        {
        }

        public Paragraph(MarginAlign align, List<Text> someTexts) : base(align,someTexts)
        {
        }

        public Paragraph(MarginAlign align, List<Text> someTexts, string aStyleClass) : base(align,someTexts,aStyleClass)
        {
        }

        public Text GetText(Guid textId)
        {
            if (!ExistText(textId))
            {
                throw new KeyNotFoundException();
            }

            return Texts.Find(x => x.Id == textId);
        }

        public Text GetTextAt(int position)
        {
            return Texts[position];
        }

        public void PutTextAtLast(Text aText)
        {
            aText.BodyId = this.Id;
            Texts.Add(aText);
        }

        public void PutTextAt(int position, Text aText)
        {
            aText.BodyId = this.Id;
            Texts.Insert(position, aText);
        }

        public void MoveTextTo(int newPosition, Guid textId)
        {
            Text aText = Texts.Find(x => x.Id == textId);
            
            Texts.Remove(aText);
            Texts.Insert(newPosition, aText);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

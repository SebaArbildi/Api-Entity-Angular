using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return texts.Find(x => x.id == textId);
        }

        public Text GetTextAt(int position)
        {
            return texts[position];
        }

        public void PutTextAtLast(Text aText)
        {
            texts.Add(aText);
        }

        public void PutTextAt(int position, Text aText)
        {
            texts.Insert(position, aText);
        }

        public void MoveTextTo(int newPosition, Guid textId)
        {
            Text aText = texts.Find(x => x.id == textId);
            
            texts.Remove(aText);
            texts.Insert(newPosition, aText);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public class Paragraph : Body
    {
        public Paragraph()
        {

        }

        public Paragraph(MarginAlign align)
        {

        }

        public Paragraph(MarginAlign align, List<Text> someTexts)
        {

        }

        public Paragraph(MarginAlign align, List<Text> someTexts, string aStyleClass)
        {

        }

        public Text getText(Guid textId)
        {
            throw new NotImplementedException();
        }

        public Text getTextAt(int position)
        {
            throw new NotImplementedException();
        }

        public void putTextAtLast(Text aText)
        {
            throw new NotImplementedException();
        }

        public void putTextAt(int position, Text aText)
        {
            throw new NotImplementedException();
        }

        public void moveTextTo(int newPosition, Guid aTextId)
        {
            throw new NotImplementedException();
        }

    }
}

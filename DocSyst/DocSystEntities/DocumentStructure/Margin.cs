using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public class Margin : Body
    {

        public Margin() : base()
        {   
        }

        public Margin(MarginAlign align) : base(align)
        {

        }

        public Margin(MarginAlign align, List<Text> someTexts) : base(align,someTexts)
        {
        }

        public Margin(MarginAlign align, List<Text> someTexts, string aStyleClass) : base(align,someTexts,aStyleClass)
        {
        }

        public void SetText(Text aText)
        {
            texts.Add(aText);
        }

        public Text GetText()
        {
            return texts[0];
        }

        public void ClearText()
        {
            texts.Clear();
        }
         
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.DocumentStructure
{
    public class Margin : Body
    {

        public Margin()
        {
            
        }

        public Margin(MarginAlign align)
        {

        }

        public Margin(MarginAlign align, List<Text> someTexts)
        {

        }

        public Margin(MarginAlign align, List<Text> someTexts, string aStyleClass)
        {

        }

        public void setText(Text aText)
        {
            throw new NotImplementedException();
        }

        public Text getText()
        {
            throw new NotImplementedException();
        }

        public void clearText()
        {
            throw new NotImplementedException();
        }
         
    }
}

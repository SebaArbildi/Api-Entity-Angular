using System.Collections.Generic;

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

        public Margin(MarginAlign align, string aStyleClass) : base(align,aStyleClass)
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
            aText.FatherBody = this;
            aText.BodyId = this.Id;
            Texts.Add(aText);
        }

        public Text GetText()
        {
            return Texts[0];
        }

        public void ClearText()
        {
            Texts.Clear();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

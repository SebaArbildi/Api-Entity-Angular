using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation
{
    public class ParagraphBusinessLogic : IParagraphBusinessLogic
    {
        private IParagraphDataAccess paragraphDataAccess;

        public ParagraphBusinessLogic()
        {
        }

        public ParagraphBusinessLogic(IParagraphDataAccess aParagraphDataAccess)
        {

        }

        public void AddParagraph(Paragraph newParagraph)
        {
            throw new NotImplementedException();
        }

        public bool AreEqual(Guid firstParagraphId, Guid secondParagraphId)
        {
            throw new NotImplementedException();
        }

        public void DeleteParagraph(Guid aParagraphId)
        {
            throw new NotImplementedException();
        }

        public Paragraph GetParagraph(Guid aParagraphId)
        {
            throw new NotImplementedException();
        }

        public IList<Paragraph> GetParagraphs()
        {
            throw new NotImplementedException();
        }

        public Text GetText(Guid aParagraphId, Guid aTextId)
        {
            throw new NotImplementedException();
        }

        public Text GetTextAt(Guid aParagraphId, int position)
        {
            throw new NotImplementedException();
        }

        public void ModifyParagraph(Paragraph newParagraph)
        {
            throw new NotImplementedException();
        }

        public void MoveTextTo(Guid aParagraphId, Guid textId, int newPosition)
        {
            throw new NotImplementedException();
        }

        public void PutTextAt(Guid aParagraphId, Text aText, int position)
        {
            throw new NotImplementedException();
        }

        public void PutTextAtLast(Text aText)
        {
            throw new NotImplementedException();
        }

        public void PutTextAtLast(Guid aParagraphId, Text aText)
        {
            throw new NotImplementedException();
        }
    }
}

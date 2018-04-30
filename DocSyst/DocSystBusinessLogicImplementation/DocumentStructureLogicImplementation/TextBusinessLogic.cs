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
    public class TextBusinessLogic : ITextBusinessLogic
    {
        private ITextDataAccess textDataAccess;

        public TextBusinessLogic()
        {
        }

        public TextBusinessLogic(ITextDataAccess aTextDataAccess)
        {

        }

        public void AddText(Text newText)
        {
            throw new NotImplementedException();
        }

        public bool AreEqual(Guid firstTextId, Guid secondTextId)
        {
            throw new NotImplementedException();
        }

        public void DeleteText(Guid aTextId)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Guid aTextId)
        {
            throw new NotImplementedException();
        }

        public Text GetText(Guid aTextId)
        {
            throw new NotImplementedException();
        }

        public IList<Text> GetTexts()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty(Guid aTextId)
        {
            throw new NotImplementedException();
        }

        public void ModifyText(Text newText)
        {
            throw new NotImplementedException();
        }
    }
}

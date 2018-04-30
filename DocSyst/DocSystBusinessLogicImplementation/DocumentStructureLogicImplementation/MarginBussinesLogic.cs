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
    public class MarginBusinessLogic : IMarginBusinessLogic
    {
        private IMarginDataAccess marginDataAccess;

        public MarginBusinessLogic()
        {
        }

        public MarginBusinessLogic(IMarginDataAccess aMarginDataAccess)
        {

        }

        public void AddMargin(Margin newMargin)
        {
            throw new NotImplementedException();
        }

        public bool AreEqual(Guid firstMarginId, Guid secondMarginId)
        {
            throw new NotImplementedException();
        }

        public void ClearText(Guid aMarginId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMargin(Guid aMarginId)
        {
            throw new NotImplementedException();
        }

        public Margin GetMargin(Guid aMarginId)
        {
            throw new NotImplementedException();
        }

        public IList<Margin> GetMargins()
        {
            throw new NotImplementedException();
        }

        public Text GetText(Guid aMarginId)
        {
            throw new NotImplementedException();
        }

        public void ModifyMargin(Margin newMargin)
        {
            throw new NotImplementedException();
        }

        public void SetText(Guid aMarginId, Text aText)
        {
            throw new NotImplementedException();
        }
    }
}

using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystEntities.StyleStructure;

namespace DocSystBusinessLogicImplementation.StyleStructureBusinessLogic
{
    public class StyleBusinessLogic : IStyleBusinessLogic
    {
        private IStyleDataAccess styleDataAccess;

        public StyleBusinessLogic()
        {
        }

        public StyleBusinessLogic(IStyleDataAccess styleDataAccess)
        {
            this.StyleDataAccess = styleDataAccess;
        }

        public IStyleDataAccess StyleDataAccess
        {
            get
            {
                return styleDataAccess;
            }

            set
            {
                styleDataAccess = value;
            }
        }

        public void Add(Style style)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Style> Get()
        {
            throw new NotImplementedException();
        }

        public Style Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Modify(Style style)
        {
            throw new NotImplementedException();
        }
    }
}

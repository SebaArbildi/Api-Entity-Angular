using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;

namespace DocSystBusinessLogicImplementation.StyleStructureBusinessLogic
{
    public class SpecificStyleBusinessLogic : ISpecificStyleBusinessLogic
    {
        private ISpecificStyleDataAccess specificStyleDataAccess;

        public SpecificStyleBusinessLogic() { }

        public SpecificStyleBusinessLogic(ISpecificStyleDataAccess specificStyleDataAccess)
        {
            this.SpecificStyleDataAccess = specificStyleDataAccess;
        }

        public ISpecificStyleDataAccess SpecificStyleDataAccess
        {
            get
            {
                return specificStyleDataAccess;
            }

            set
            {
                specificStyleDataAccess = value;
            }
        }

        public void Add(SpecificStyle specificStyle)
        {
            throw new NotImplementedException();
        }
    }
}

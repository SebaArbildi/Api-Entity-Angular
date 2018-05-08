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
    public class StyleClassBusinessLogic : IStyleClassBusinessLogic
    {
        private IStyleClassDataAccess styleClassDataAccess;
        public StyleClassBusinessLogic() { }

        public StyleClassBusinessLogic(IStyleClassDataAccess styleClassDataAccess)
        {
            this.StyleClassDataAccess = styleClassDataAccess;
        }

        public IStyleClassDataAccess StyleClassDataAccess
        {
            get
            {
                return styleClassDataAccess;
            }

            set
            {
                styleClassDataAccess = value;
            }
        }

         
        public void Add(StyleClass styleClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IList<StyleClass> Get()
        {
            throw new NotImplementedException();
        }

        public StyleClass Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Modify(StyleClass styleClass)
        {
            throw new NotImplementedException();
        }
    }
}

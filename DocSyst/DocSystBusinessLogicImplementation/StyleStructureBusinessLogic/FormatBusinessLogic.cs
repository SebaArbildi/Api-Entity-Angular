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
    public class FormatBusinessLogic : IFormatBusinessLogic
    {
        private IFormatDataAccess formatDataAccess;
        private IStyleClassBusinessLogic styleClassBusinessLogic;

        public FormatBusinessLogic() { }
        public FormatBusinessLogic(IFormatDataAccess formatDataAccess, IStyleClassBusinessLogic styleClassBusinessLogic)
        {
            FormatDataAccess = formatDataAccess;
            StyleClassBusinessLogic = styleClassBusinessLogic;
        }

        public IFormatDataAccess FormatDataAccess
        {
            get
            {
                return formatDataAccess;
            }

            set
            {
                formatDataAccess = value;
            }
        }

        public IStyleClassBusinessLogic StyleClassBusinessLogic
        {
            get
            {
                return styleClassBusinessLogic;
            }

            set
            {
                styleClassBusinessLogic = value;
            }
        }

        public void Add(Format format)
        {
            throw new NotImplementedException();
        }

        public void AddStyle(Guid id, StyleClass styleClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Format> Get()
        {
            throw new NotImplementedException();
        }

        public void Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Modify(Format format)
        {
            throw new NotImplementedException();
        }

        public void RemoveStyle(Guid id1, Guid id2)
        {
            throw new NotImplementedException();
        }
    }
}

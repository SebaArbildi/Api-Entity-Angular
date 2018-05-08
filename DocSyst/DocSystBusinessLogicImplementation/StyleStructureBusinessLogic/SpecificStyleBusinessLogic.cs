using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
using System;
using System.Collections.Generic;
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
            if (!SpecificStyleIsNull(specificStyle))
            {
                if (!Exists(specificStyle.Id))
                {
                    SpecificStyleDataAccess.Add(specificStyle);
                }
                else
                {
                    throw new DuplicateWaitObjectException(specificStyle.Id + " already exists");
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        public void Delete(Guid id)
        {
            if (Exists(id))
            {
                SpecificStyleDataAccess.Delete(id);
            }
            else
            {
                throw new ArgumentException("Id doesn't exist " + id);
            }
        }

        public IList<SpecificStyle> Get()
        {
            return SpecificStyleDataAccess.Get();
        }

        public SpecificStyle Get(Guid id)
        {
            if (Exists(id))
            {
                return SpecificStyleDataAccess.Get(id);
            }
            else
            {
                throw new ArgumentException("Id doesn't exist " + id);
            }
        }

        public void Modify(SpecificStyle specificStyle)
        {
            if (!SpecificStyleIsNull(specificStyle))
            {
                if (Exists(specificStyle.Id))
                {

                    SpecificStyleDataAccess.Modify(specificStyle);
                }
                else
                {
                    throw new ArgumentException("SpecificStyle doesn't exist " + specificStyle.Id);
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        private bool SpecificStyleIsNull(SpecificStyle specificStyle)
        {
            return specificStyle == null || specificStyle.Implementation == null || specificStyle.Name == null;
        }

        private bool Exists(Guid id)
        {
            return SpecificStyleDataAccess.Exists(id);
        }
    }
}


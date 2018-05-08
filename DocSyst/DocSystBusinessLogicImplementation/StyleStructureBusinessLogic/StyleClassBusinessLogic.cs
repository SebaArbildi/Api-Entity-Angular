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
            if (!StyleClassIsNull(styleClass))
            {
                if (!Exists(styleClass.Id))
                {
                    StyleClassDataAccess.Add(styleClass);
                }
                else
                {
                    throw new DuplicateWaitObjectException(styleClass.Id + " already exists");
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
                StyleClassDataAccess.Delete(id);
            }
            else
            {
                throw new ArgumentException("Id doesn't exist " + id);
            }
        }

        public IList<StyleClass> Get()
        {
            return StyleClassDataAccess.Get();
        }

        public StyleClass Get(Guid id)
        {
            if (Exists(id))
            {
                return StyleClassDataAccess.Get(id);
            }
            else
            {
                throw new ArgumentException("Id doesn't exist " + id);
            }
        }

        public void Modify(StyleClass styleClass)
        {
            if (!StyleClassIsNull(styleClass))
            {
                if (Exists(styleClass.Id))
                {

                    StyleClassDataAccess.Modify(styleClass);
                }
                else
                {
                    throw new ArgumentException("StyleClass doesn't exist " + styleClass.Id);
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        private bool StyleClassIsNull(StyleClass styleClass)
        {
            return styleClass == null || styleClass.Name == null || styleClass.InheritedPlusProperStyles == null ||
                styleClass.InheritedStyleClass == null || styleClass.Observers == null || styleClass.ProperStyles == null;
        }

        private bool Exists(Guid id)
        {
            return this.StyleClassDataAccess.Exists(id);
        }
    }
}

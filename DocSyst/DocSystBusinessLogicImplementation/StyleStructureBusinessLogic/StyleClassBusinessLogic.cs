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
        private IStyleBusinessLogic styleBusinessLogic;
        public StyleClassBusinessLogic() { }

        public StyleClassBusinessLogic(IStyleClassDataAccess styleClassDataAccess, IStyleBusinessLogic styleBusinessLogic)
        {
            this.StyleClassDataAccess = styleClassDataAccess;
            this.StyleBusinessLogic = styleBusinessLogic;
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

        public IStyleBusinessLogic StyleBusinessLogic
        {
            get
            {
                return styleBusinessLogic;
            }

            set
            {
                styleBusinessLogic = value;
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

        public void AddStyle(Guid styleClassId, Style style)
        {
            if (Exists(styleClassId))
            {
                if (StyleBusinessLogic.Exists(style.Name))
                {
                    StyleClass styleClass = StyleClassDataAccess.Get(styleClassId);
                    styleClass.AddStyle(style);
                    StyleClassDataAccess.Modify(styleClass);
                }
                else
                {
                    throw new ArgumentException("Style doesn't exist " + style.Name);
                }
            }
            else
            {
                throw new ArgumentException("StyleClass doesn't exist " + styleClassId);
            }
        }

        public void RemoveStyle(Guid styleClassId, string styleName)
        {
            if (Exists(styleClassId))
            {
                if (StyleBusinessLogic.Exists(styleName))
                {
                    StyleClass styleClass = StyleClassDataAccess.Get(styleClassId);
                    Style style = StyleBusinessLogic.Get(styleName);
                    styleClass.RemoveStyle(style);
                    StyleClassDataAccess.Modify(styleClass);
                }
                else
                {
                    throw new ArgumentException("Style doesn't exist " + styleName);
                }
            }
            else
            {
                throw new ArgumentException("StyleClass doesn't exist " + styleClassId);
            }
        }

        public bool Exists(Guid id)
        {
            return this.StyleClassDataAccess.Exists(id);
        }

        private bool StyleClassIsNull(StyleClass styleClass)
        {
            return styleClass == null || styleClass.Name == null || styleClass.InheritedPlusProperStyles == null ||
                styleClass.Observers == null || styleClass.ProperStyles == null;
        }
    }
}

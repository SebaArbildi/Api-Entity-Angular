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
            if (!StyleIsNull(style))
            {
                if (!Exists(style.Name))
                {
                    StyleDataAccess.Add(style);
                }
                else
                {
                    throw new DuplicateWaitObjectException(style.Name + " already exists");
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        public void Delete(string name)
        {
            if (name != null)
            {
                if (Exists(name))
                {
                    StyleDataAccess.Delete(name);
                }
                else
                {
                    throw new ArgumentException("Style doesn't exist", name);
                }
            }
            else
            {
                throw new ArgumentNullException(name);
            }
        }

        public IList<Style> Get()
        {
            return StyleDataAccess.Get();
        }

        public Style Get(string name)
        {
            if (name != null)
            {
                if (Exists(name))
                {
                    return StyleDataAccess.Get(name);
                }
                else
                {
                    throw new ArgumentException("Style doesn't exist", name);
                }
            }
            else
            {
                throw new ArgumentNullException(name);
            }
        }

        public void Modify(Style style)
        {
            if (!StyleIsNull(style))
            {
                if (Exists(style.Name))
                {

                    StyleDataAccess.Modify(style);
                }
                else
                {
                    throw new ArgumentException("Style doesn't exist", style.Name);
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }

        private bool StyleIsNull(Style style)
        {
            return style == null || style.Name == null || style.Implementation == null;
        }

        private bool Exists(string name)
        {
            return this.StyleDataAccess.Exists(name);
        }
    }
}

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
            if (!FormatIsNull(format))
            {
                if (!Exists(format.Id))
                {
                    FormatDataAccess.Add(format);
                }
                else
                {
                    throw new DuplicateWaitObjectException(format.Id + " already exists");
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
                FormatDataAccess.Delete(id);
            }
            else
            {
                throw new ArgumentException("Format doesn't exist " + id);
            }
        }

        public IList<Format> Get()
        {
            return FormatDataAccess.Get();
        }

        public Format Get(Guid id)
        {
            if (Exists(id))
            {
                return FormatDataAccess.Get(id);
            }
            else
            {
                throw new ArgumentException("Format doesn't exist " + id);
            }
        }

        public void Modify(Format format)
        {
            if (!FormatIsNull(format))
            {
                if (Exists(format.Id))
                {
                    FormatDataAccess.Modify(format);
                }
                else
                {
                    throw new ArgumentException("Format doesn't exist " + format.Id);
                }
            }
            else
            {
                throw new ArgumentNullException("Null references");
            }
        }
        public void AddStyle(Guid formatId, StyleClass styleClass)
        {
            if (Exists(formatId))
            {
                if (StyleClassBusinessLogic.Exists(styleClass.Id))
                {
                    Format format = FormatDataAccess.Get(formatId);
                    format.AddStyleClass(styleClass);
                    FormatDataAccess.Modify(format);
                }
                else
                {
                    throw new ArgumentException("StyleClass doesn't exist styleClass.Name");
                }
            }
            else
            {
                throw new ArgumentException("StyleClass doesn't exist styleClass.Name");
            }
        }

        public void RemoveStyle(Guid formatId, Guid styleClassId)
        {
            if (Exists(formatId))
            {
                if (StyleClassBusinessLogic.Exists(styleClassId))
                {
                    Format format = FormatDataAccess.Get(formatId);
                    StyleClass styleClass = StyleClassBusinessLogic.Get(styleClassId);
                    format.RemoveStyleClass(styleClass);
                    FormatDataAccess.Modify(format);
                }
                else
                {
                    throw new ArgumentException("StyleClass doesn't exist styleClass.Name");
                }
            }
            else
            {
                throw new ArgumentException("StyleClass doesn't exist styleClass.Name");
            }
        }

        private bool FormatIsNull(Format format)
        {
            return format == null || format.Name == null || format.StyleClasses == null;
        }

        private bool Exists(Guid id)
        {
            return this.FormatDataAccess.Exists(id);
        }
    }
}

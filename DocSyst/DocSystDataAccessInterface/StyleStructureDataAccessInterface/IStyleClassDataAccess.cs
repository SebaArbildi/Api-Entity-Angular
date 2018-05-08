using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessInterface.StyleStructureDataAccessInterface
{
    public interface IStyleClassDataAccess
    {
        void Add(StyleClass styleClass);
        StyleClass Get(Guid id);
        void Delete(Guid id);
        IList<StyleClass> Get();
        void Modify(StyleClass styleClass);
        bool Exists(Guid id);
    }
}

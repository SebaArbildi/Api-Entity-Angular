using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface
{
    public interface IStyleClassBusinessLogic
    {
        void Add(StyleClass styleClass);
        void Delete(Guid guid);
        void Modify(StyleClass styleClass);
        IList<StyleClass> Get();
        StyleClass Get(Guid id);
    }
}

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
        void Delete(Guid id);
        void Modify(StyleClass styleClass);
        IList<StyleClass> Get();
        StyleClass Get(Guid id);
        void AddStyle(Guid styleClassId, Style style);
        void RemoveStyle(Guid styleClassId, string styleName);
        bool Exists(Guid id);
    }
}

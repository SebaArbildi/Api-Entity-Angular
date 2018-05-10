using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface
{
    public interface ISpecificStyleBusinessLogic
    {
        void Add(SpecificStyle specificStyle);
        SpecificStyle Get(Guid id);
        void Delete(Guid id);
        void Modify(SpecificStyle specificStyle);
        IList<SpecificStyle> Get();
    }
}

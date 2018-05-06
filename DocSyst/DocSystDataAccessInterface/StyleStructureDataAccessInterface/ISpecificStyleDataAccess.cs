using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessInterface.StyleStructureDataAccessInterface
{
    public interface ISpecificStyleDataAccess
    {
        void Add(SpecificStyle specificStyle);
        void Delete(Guid id);
        SpecificStyle Get(Guid id);
        void Modify(SpecificStyle specificStyle);
        IList<SpecificStyle> Get();
    }
}

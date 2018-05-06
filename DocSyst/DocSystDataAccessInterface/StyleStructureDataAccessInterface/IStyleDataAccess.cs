using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessInterface.StyleStructureDataAccessInterface
{
    public interface IStyleDataAccess
    {
        void Add(Style style);
        Style Get(string name);
        void Delete(string name);
        IList<Style> Get();
        void Modify(Style style);
    }
}

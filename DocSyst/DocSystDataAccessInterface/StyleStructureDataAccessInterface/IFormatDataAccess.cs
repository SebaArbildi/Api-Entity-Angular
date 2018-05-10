using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystDataAccessInterface.StyleStructureDataAccessInterface
{
    public interface IFormatDataAccess
    {
        void Add(Format format);
        Format Get(Guid id);
        void Delete(Guid id);
        IList<Format> Get();
        void Modify(Format format);
        bool Exists(Guid id);
    }
}

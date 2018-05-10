using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.DocumentStructureDataAccessInterface
{
    public interface IBodyDataAccess
    {
        void Add(Body aBody);
        Body Get(Guid id);
        void Delete(Guid id);
        void Modify(Body aBody);
        IList<Body> Get();
        bool Exists(Guid aBody);
    }
}

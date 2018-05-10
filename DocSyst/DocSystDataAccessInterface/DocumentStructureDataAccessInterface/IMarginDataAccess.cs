using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.DocumentStructureDataAccessInterface
{
    public interface IMarginDataAccess
    {
        void Add(Margin aMargin);
        Margin Get(Guid id);
        void Delete(Guid id);
        void Modify(Margin aMargin);
        IList<Margin> Get();
        bool Exists(Guid aMargin);
        void ClearText(Guid aMargin);
    }
}

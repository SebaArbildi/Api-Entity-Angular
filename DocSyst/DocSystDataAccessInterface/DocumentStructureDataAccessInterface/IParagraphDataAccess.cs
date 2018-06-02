using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.DocumentStructureDataAccessInterface
{
    public interface IParagraphDataAccess
    {
        void Add(Paragraph aParagraph);
        Paragraph Get(Guid id);
        void Delete(Guid id);
        void Modify(Paragraph aParagraph);
        IList<Paragraph> Get();
        bool Exists(Guid aParagraph);
        void ClearText(Guid aParagraph);
    }
}

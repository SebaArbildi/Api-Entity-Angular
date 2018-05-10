using System;
using DocSystEntities.DocumentStructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.DocumentStructureDataAccessInterface
{
    public interface ITextDataAccess
    {
        void Add(Text aText);
        Text Get(Guid id);
        List<Text> GetTextsInBody(Guid BodyId);
        void Delete(Guid id);
        void Modify(Text aText);
        IList<Text> Get();
        bool Exists(Guid aText);
        Guid GetDocumentId(Guid aTextId);
    }
}

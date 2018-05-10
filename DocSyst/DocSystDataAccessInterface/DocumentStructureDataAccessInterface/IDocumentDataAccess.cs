using System;
using System.Collections.Generic;
using DocSystEntities.DocumentStructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.DocumentStructureDataAccessInterface
{
    public interface IDocumentDataAccess
    {
        void Add(Document aDocument);
        Document Get(Guid id);
        void Delete(Guid id);
        void Modify(Document aDocument);
        IList<Document> Get();
        IList<Document> Get(string Username);
        bool Exists(Guid aDocument);
    }
}

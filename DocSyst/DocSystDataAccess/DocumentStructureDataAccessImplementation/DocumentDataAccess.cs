using System;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.DocumentStructure;

namespace DocSystDataAccess.DocumentStructureDataAccessImplementation
{
    public class DocumentDataAccess : IDocumentDataAccess
    {
        public void Add(Document aDocument)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid aDocument)
        {
            throw new NotImplementedException();
        }

        public Document Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Document> Get()
        {
            throw new NotImplementedException();
        }

        public void Modify(Document aDocument)
        {
            throw new NotImplementedException();
        }
    }
}

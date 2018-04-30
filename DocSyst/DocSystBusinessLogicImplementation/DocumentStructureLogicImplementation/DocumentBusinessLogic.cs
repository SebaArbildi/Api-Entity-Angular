using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation
{
    public class DocumentBusinessLogic : IDocumentBusinessLogic
    {
        private IDocumentDataAccess documentDataAccess;

        public DocumentBusinessLogic()
        {
        }

        public DocumentBusinessLogic(IDocumentDataAccess aDocumentDataAccess)
        {

        }

        public void AddDocument(Document newDocument)
        {
            throw new NotImplementedException();
        }

        public bool AreEqual(Guid firstDocumentId, Guid secondDocumentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocument(Guid aDocumentId)
        {
            throw new NotImplementedException();
        }

        public bool ExistDocumentPart(Guid aDocumentId, MarginAlign? align)
        {
            throw new NotImplementedException();
        }

        public Document GetDocument(Guid aDocumentId)
        {
            throw new NotImplementedException();
        }

        public Body GetDocumentPart(Guid aDocumentId, MarginAlign align)
        {
            throw new NotImplementedException();
        }

        public IList<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public void ModifyDocument(Document newDocument)
        {
            throw new NotImplementedException();
        }

        public void SetDocumentPart(Guid aDocumentId, MarginAlign? align, Body aDocumentPart)
        {
            throw new NotImplementedException();
        }
    }
}

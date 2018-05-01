using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.DocumentStructureLogicInterface
{
    public interface IDocumentBusinessLogic
    {
        void AddDocument(Document newDocument);
        void DeleteDocument(Guid aDocumentId);
        void ModifyDocument(Document newDocument);
        IList<Document> GetDocuments();
        Document GetDocument(Guid aDocumentId);
        List<Document> GetDocument(Guid aDocumentId, Guid aUserId);
        Body GetDocumentPart(Guid aDocumentId, MarginAlign align);
        void SetDocumentPart(Guid aDocumentId, MarginAlign? align, Body aDocumentPart);
        bool ExistDocumentPart(Guid aDocumentId, MarginAlign? align);
        bool AreEqual(Guid firstDocumentId, Guid secondDocumentId);
        bool Exist(Guid aDocumentId);
    }
}

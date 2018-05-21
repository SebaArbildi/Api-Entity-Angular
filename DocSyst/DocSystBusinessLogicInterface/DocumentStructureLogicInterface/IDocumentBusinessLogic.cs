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
        IList<Document> GetDocuments(string userToken);
        Body GetDocumentMargin(Guid aDocumentId, MarginAlign align);
        void SetDocumentMargin(Guid aDocumentId, MarginAlign? align, Body aDocumentPart);
        Paragraph GetDocumentParagraph(Guid aDocumentId, int index);
        void AddDocumentParagraphAtLast(Guid aDocumentId, Paragraph aParagraph);
        void AddDocumentParagraphAt(Guid aDocumentId, int index, Paragraph aParagraph);
        void MoveDocumentParagraphTo(Guid aDocumentId, int index, Guid aParagraphId);
        bool ExistDocumentMargin(Guid aDocumentId, MarginAlign? align);
        bool AreEqual(Guid firstDocumentId, Guid secondDocumentId);
        bool Exist(Guid aDocumentId);
    }
}

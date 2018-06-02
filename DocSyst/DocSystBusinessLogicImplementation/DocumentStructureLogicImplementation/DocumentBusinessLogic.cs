using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation
{
    public class DocumentBusinessLogic : IDocumentBusinessLogic
    {
        private IDocumentDataAccess documentDataAccess;
        private IUserDataAccess userDataAccess;

        public DocumentBusinessLogic()
        {
        }

        public DocumentBusinessLogic(IDocumentDataAccess aDocumentDataAccess, IUserDataAccess aUserDataAccess)
        {
            documentDataAccess = aDocumentDataAccess;
            userDataAccess = aUserDataAccess;
        }

        public void AddDocument(Document newDocument)
        {
            if (documentDataAccess.Exists(newDocument.Id))
            {
                throw new DuplicateWaitObjectException("newDocument.Id"
                    , "The Document you want to enter already exists in the database.");
            }

            documentDataAccess.Add(newDocument);
        }

        public bool AreEqual(Guid firstDocumentId, Guid secondDocumentId)
        {
            if (!documentDataAccess.Exists(firstDocumentId))
            {
                throw new ArgumentException("The first document argument not exist in database."
                    , "firstDocumentId");
            }
            if (!documentDataAccess.Exists(secondDocumentId))
            {
                throw new ArgumentException("The second document argument not exist in database."
                    , "secondDocumentId");
            }

            Document firstDocument = documentDataAccess.Get(firstDocumentId);
            Document secondDocument = documentDataAccess.Get(secondDocumentId);

            return firstDocument.Equals(secondDocument);
        }

        public void DeleteDocument(Guid aDocumentId)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            documentDataAccess.Delete(aDocumentId);
        }

        public bool Exist(Guid aDocumentId)
        {
            return documentDataAccess.Exists(aDocumentId);
        }

        public bool ExistDocumentMargin(Guid aDocumentId, MarginAlign? align)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            return document.ExistDocumentMargin(align);
        }

        public Document GetDocument(Guid aDocumentId)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            return documentDataAccess.Get(aDocumentId);
        }

        public IList<Document> GetDocuments(string userToken)
        {
            if (userDataAccess.Get(userToken) == null)
            {
                throw new ArgumentException("The User argument not exist in database."
                    , "userToken");
            }

            User user = userDataAccess.Get(userToken);

            IList<Document> documents = documentDataAccess.Get(user.Username);

            return documents;
        }

        public Margin GetDocumentMargin(Guid aDocumentId, MarginAlign align)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            if (!document.ExistDocumentMargin(align))
            {
                throw new ArgumentException("The current document does not have the specified part.");
            }

            return document.GetDocumentMargin(align);
        }

        public IList<Document> GetDocuments()
        {
            return documentDataAccess.Get();
        }

        public void ModifyDocument(Document newDocument)
        {
            if (!documentDataAccess.Exists(newDocument.Id))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "newDocument.Id");
            }

            documentDataAccess.Modify(newDocument);
        }

        public void SetDocumentMargin(Guid aDocumentId, MarginAlign? align, Margin aDocumentPart)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            document.SetDocumentMargin(align, aDocumentPart);

            documentDataAccess.Modify(document);
        }

        public Paragraph GetDocumentParagraph(Guid aDocumentId, int index)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            return document.GetDocumentParagraphAt(index);
        }

        public void AddDocumentParagraphAtLast(Guid aDocumentId, Paragraph aParagraph)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            document.AddDocumentParagraphAtLast(aParagraph);

            documentDataAccess.Modify(document);
        }

        public void AddDocumentParagraphAt(Guid aDocumentId, int index, Paragraph aParagraph)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            document.AddDocumentParagraphAt(aParagraph, index);

            documentDataAccess.Modify(document);
        }

        public void MoveDocumentParagraphTo(Guid aDocumentId, int index, Guid aParagraphId)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            document.MoveParagraphTo(index, aParagraphId);

            documentDataAccess.Modify(document);
        }
    }
}

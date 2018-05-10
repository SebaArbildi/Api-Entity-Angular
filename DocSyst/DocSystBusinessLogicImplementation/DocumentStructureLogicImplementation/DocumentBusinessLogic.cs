using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
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

        public bool ExistDocumentPart(Guid aDocumentId, MarginAlign? align)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            return document.ExistDocumentPart(align);
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
            if (userDataAccess.Get(userToken)==null)
            {
                throw new ArgumentException("The User argument not exist in database."
                    , "userToken");
            }

            Guid guid = Guid.Parse(userToken);
            User user = userDataAccess.Get(guid);

            IList<Document> documents = documentDataAccess.Get(user.Username);

            return documents;
        }

        public Body GetDocumentPart(Guid aDocumentId, MarginAlign align)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            if (!document.ExistDocumentPart(align))
            {
                throw new ArgumentException("The current document does not have the specified part.");
            }

            return document.GetDocumentPart(align);
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

        public void SetDocumentPart(Guid aDocumentId, MarginAlign? align, Body aDocumentPart)
        {
            if (!documentDataAccess.Exists(aDocumentId))
            {
                throw new ArgumentException("The document argument not exist in database."
                    , "aDocumentId");
            }

            Document document = documentDataAccess.Get(aDocumentId);

            document.SetDocumentPart(align, aDocumentPart);

            documentDataAccess.Modify(document);
        }
    }
}

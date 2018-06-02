using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation
{
    public class DocumentDataAccess : IDocumentDataAccess
    {
        public void Add(Document aDocument)
        {
            IBodyDataAccess bodyDataAccess = new BodyDataAccess();
            foreach (Body body in aDocument.DocumentParts)
            {
                bodyDataAccess.Add(body);
            }

            using (DocSystDbContext context = new DocSystDbContext())
            {
                aDocument.CreatorUser = AttachCreatorUser(context, aDocument.CreatorUser);
                aDocument.DocumentParts = AttachDocumentPartList(context, aDocument.DocumentParts).ToList();
                context.Documents.Add(aDocument);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            Document document = Get(id);

            using (DocSystDbContext context = new DocSystDbContext())
            {
                IList<Body> bodyList = AttachDocumentPartList(context, document.DocumentParts);
                document.DocumentParts = bodyList.ToList();
                context.Documents.Attach(document);
                /* List<Paragraph> paragraphList = new List<Paragraph>();
                 List<Margin> marginList = new List<Margin>();

                 foreach (Body aDocumentPart in document.DocumentParts)
                 {
                     if (aDocumentPart.Align == MarginAlign.PARAGRAPH)
                     {
                         context.Paragraphs.Attach((Paragraph)aDocumentPart);
                         paragraphList.Add((Paragraph)aDocumentPart);
                     }
                     else if(aDocumentPart.Align == MarginAlign.HEADER || aDocumentPart.Align == MarginAlign.FOOTER)
                     {
                         context.Margins.Attach((Margin)aDocumentPart);
                         marginList.Add((Margin)aDocumentPart);
                     }

                     textList = textList.Concat(AttachTextList(context, aDocumentPart.Texts)).ToList();
                 }
                 context.Users.Attach(document.CreatorUser);
                 context.Documents.Attach(document);
                 if (textList.Any())
                 {
                     context.Texts.RemoveRange(textList);
                 }
                 if (paragraphList.Any())
                 {
                     context.Paragraphs.RemoveRange(paragraphList);
                 }
                 if (marginList.Any())
                 {
                     context.Margins.RemoveRange(marginList);
                 }
                 context.Users.Remove(document.CreatorUser);*/
                context.Documents.Remove(document);
                context.SaveChanges();
            }
        }

        private User AttachCreatorUser(DocSystDbContext context, User creatorUser)
        {
            User user = context.Users.Where(userDb => userDb.Username == creatorUser.Username).FirstOrDefault();
            context.Users.Attach(user);
            return user;
        }

        public bool Exists(Guid aDocument)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Documents.Any(documentDb => documentDb.Id == aDocument);
            }
            return exists;
        }

        public Document Get(Guid id)
        {
            Document document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = context.Documents.Include("CreatorUser")
                                            .Include("DocumentParts").Where(documenthDb => documenthDb.Id == id)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))
                                            .FirstOrDefault();
            }
            return document;
        }

        public IList<Document> Get()
        {
            IList<Document> document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = (context.Documents.Include("DocumentParts")
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))
                                            .Include("CreatorUser")).ToList<Document>();
            }
            return document;
        }

        public IList<Document> Get(string Username)
        {
            IList<Document> document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = (context.Documents.Include(documenthDb => documenthDb.CreatorUser)
                                            .Where(documenthDb =>  documenthDb.CreatorUser.Username == Username)
                                            .Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))).ToList<Document>();
            }
            return document;
        }

        public void Modify(Document aDocument)
        {
            IBodyDataAccess bodyDataAccess = new BodyDataAccess();
            foreach (Body body in aDocument.DocumentParts)
            {
                bodyDataAccess.Add(body);
            }

            using (DocSystDbContext context = new DocSystDbContext())
            {
                IList<Body> bodyList = AttachDocumentPartList(context, aDocument.DocumentParts);
                aDocument.DocumentParts = bodyList.ToList();

                /*Document actualDocument = context.Documents.Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))
                                            .FirstOrDefault(documenthDb => documenthDb.Id == aDocument.Id);*/

                Document actualDocument = context.Documents.Include("DocumentParts").FirstOrDefault(documenthDb => documenthDb.Id == aDocument.Id);

                context.Entry(actualDocument).Entity.DocumentParts = aDocument.DocumentParts;
                context.Entry(actualDocument).CurrentValues.SetValues(aDocument);

                context.SaveChanges();
            }
        }

        private IList<Body> AttachDocumentPartList(DocSystDbContext context, IList<Body> documentParts)
        {
            IList<Body> bodys = new List<Body>();

            foreach (Body body in documentParts)
            {
                Body bdy = context.Bodys.Include("Texts").Where(bdyDb => bdyDb.Id == body.Id).FirstOrDefault();
                context.Bodys.Attach(bdy);
                bodys.Add(bdy);
            }
            return bodys;
        }
    }
}

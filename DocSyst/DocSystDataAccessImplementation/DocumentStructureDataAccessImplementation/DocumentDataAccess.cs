using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
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
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Documents.Add(aDocument);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            Document document = Get(id);

            using (DocSystDbContext context = new DocSystDbContext())
            {
                
                foreach (Body aDocumentPart in document.DocumentParts)
                {
                    foreach (Text aText in aDocumentPart.Texts)
                    {
                        context.Texts.Attach(aText);
                        //context.Texts.Remove(aText);
                    }

                    if (aDocumentPart.Align == MarginAlign.PARAGRAPH)
                    {
                        context.Paragraphs.Attach((Paragraph)aDocumentPart);
                        //context.Paragraphs.Remove((Paragraph)aDocumentPart);
                    }
                    else if(aDocumentPart.Align == MarginAlign.HEADER || aDocumentPart.Align == MarginAlign.FOOTER)
                    {
                        context.Margins.Attach((Margin)aDocumentPart);
                        //context.Margins.Remove((Margin)aDocumentPart);
                    }
                }

                context.Documents.Attach(document);
                context.Documents.Remove(document);
                context.SaveChanges();
            }
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
                document = context.Documents.Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))
                                            .FirstOrDefault(documenthDb => documenthDb.Id == id);
            }
            return document;
        }

        public IList<Document> Get()
        {
            IList<Document> document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = (context.Documents.Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))).ToList<Document>();
            }
            return document;
        }

        public IList<Document> Get(string Username)
        {
            IList<Document> document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = (context.Documents.Where(documenthDb =>  Username == documenthDb.GetCreatorUsername())
                                            .Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))).ToList<Document>();
            }
            return document;
        }

        public void Modify(Document aDocument)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Document actualDocument = context.Documents.Include(documenthDb => documenthDb.DocumentParts)
                                            .Include(documenthDb => documenthDb.DocumentParts.Select(bodyDb => bodyDb.Texts))
                                            .FirstOrDefault(documenthDb => documenthDb.Id == aDocument.Id);

                context.Entry(actualDocument).CurrentValues.SetValues(aDocument);
                actualDocument.DocumentParts = aDocument.DocumentParts;

                context.SaveChanges();
            }
        }
    }
}

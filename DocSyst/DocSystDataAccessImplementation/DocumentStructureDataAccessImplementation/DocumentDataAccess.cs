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
                List<Text> textList = new List<Text>();
                List<Paragraph> paragraphList = new List<Paragraph>();
                List<Margin> marginList = new List<Margin>();

                foreach (Body aDocumentPart in document.DocumentMargins)
                {
                    context.Margins.Attach((Margin)aDocumentPart);
                    marginList.Add((Margin)aDocumentPart);

                    textList = textList.Concat(AttachTextList(context, aDocumentPart.Texts)).ToList();
                }

                foreach (Paragraph aDocumentParagraph in document.DocumentParagraphs)
                {
                    context.Paragraphs.Attach(aDocumentParagraph);
                    paragraphList.Add(aDocumentParagraph);

                    textList = textList.Concat(AttachTextList(context, aDocumentParagraph.Texts)).ToList();
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
                context.Users.Remove(document.CreatorUser);
                context.Documents.Remove(document);
                context.SaveChanges();
            }
        }

        private List<Text> AttachTextList(DocSystDbContext context, IList<Text> textList)
        {
            List<Text> texts = new List<Text>();
            foreach (Text text in textList)
            {
                Text txt = context.Texts.Where(textDb => textDb.Id == text.Id).FirstOrDefault();
                context.Texts.Attach(txt);
                texts.Add(txt);
            }
            return texts;
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
                                            .Include("DocumentMargins").Where(documenthDb => documenthDb.Id == id)
                                            .Include(documenthDb => documenthDb.DocumentMargins.Select(bodyDb => bodyDb.Texts))
                                            .Include("DocumentParagraphs").Where(documenthDb => documenthDb.Id == id)
                                            .Include(documenthDb => documenthDb.DocumentParagraphs.Select(bodyDb => bodyDb.Texts))
                                            .FirstOrDefault();
            }
            return document;
        }

        public IList<Document> Get()
        {
            IList<Document> document = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                document = (context.Documents.Include("DocumentMargins")
                                            .Include(documenthDb => documenthDb.DocumentMargins.Select(bodyDb => bodyDb.Texts))
                                            .Include("DocumentParagraphs")
                                            .Include(documenthDb => documenthDb.DocumentParagraphs.Select(bodyDb => bodyDb.Texts))
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
                                            .Include(documenthDb => documenthDb.DocumentMargins)
                                            .Include(documenthDb => documenthDb.DocumentMargins.Select(bodyDb => bodyDb.Texts))
                                            .Include("DocumentParagraphs").Where(documenthDb => documenthDb.CreatorUser.Username == Username)
                                            .Include(documenthDb => documenthDb.DocumentParagraphs.Select(bodyDb => bodyDb.Texts))).ToList<Document>();
            }
            return document;
        }

        public void Modify(Document aDocument)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Document actualDocument = context.Documents.Include(documenthDb => documenthDb.DocumentMargins)
                                            .Include(documenthDb => documenthDb.DocumentMargins.Select(bodyDb => bodyDb.Texts))
                                            .Include("DocumentParagraphs")
                                            .Include(documenthDb => documenthDb.DocumentParagraphs.Select(bodyDb => bodyDb.Texts))
                                            .Include(documenthDb => documenthDb.CreatorUser)
                                            .FirstOrDefault(documenthDb => documenthDb.Id == aDocument.Id);

                context.Entry(actualDocument).CurrentValues.SetValues(aDocument);
                actualDocument.DocumentMargins = aDocument.DocumentMargins;

                context.SaveChanges();
            }
        }
    }
}

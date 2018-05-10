using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation
{
    public class ParagraphDataAccess : IParagraphDataAccess
    {
        public void Add(Paragraph aParagraph)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Paragraphs.Add(aParagraph);
                context.SaveChanges();
            }
        }

        public void ClearText(Guid aParagraph)
        {
            Paragraph paragraphToClear = Get(aParagraph);
            paragraphToClear.ClearText();
            Modify(paragraphToClear);
        }

        public void Delete(Guid id)
        {
            Paragraph paragraph = Get(id);

            using (DocSystDbContext context = new DocSystDbContext())
            {
                List<Text> textList = AttachTextList(context, paragraph.Texts);
                paragraph.Texts = textList;
                context.Paragraphs.Attach(paragraph);
                context.Texts.RemoveRange(textList);
                context.Paragraphs.Remove(paragraph);
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

        public bool Exists(Guid aParagraph)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Paragraphs.Any(paragraphDb => paragraphDb.Id == aParagraph);
            }
            return exists;
        }

        public Paragraph Get(Guid id)
        {
            Paragraph paragraph = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                paragraph = context.Paragraphs.Include(paragraphDb => paragraphDb.Texts)
                                              .FirstOrDefault(paragraphDb => paragraphDb.Id == id);
            }
            return paragraph;
        }

        public IList<Paragraph> Get()
        {
            IList<Paragraph> paragraphs = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                paragraphs = (context.Paragraphs.Include(paragraphDb => paragraphDb.Texts)).ToList<Paragraph>();
            }
            return paragraphs;
        }

        public void Modify(Paragraph aParagraph)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Paragraph actualParagraph = context.Paragraphs.Include(paragraphDb => paragraphDb.Texts)
                                              .FirstOrDefault(paragraphDb => paragraphDb.Id == aParagraph.Id);

                context.Entry(actualParagraph).CurrentValues.SetValues(aParagraph);
                actualParagraph.Texts = aParagraph.Texts;

                context.SaveChanges();
            }
        }
    }
}

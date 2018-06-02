using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation
{
    public class TextDataAccess : ITextDataAccess
    {
        public void Add(Text aText)
        {
            if (!Exists(aText.Id))
            {
                using (DocSystDbContext context = new DocSystDbContext())
                {
                    context.Texts.Add(aText);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            Text text = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Texts.Attach(text);
                context.Texts.Remove(text);
                context.SaveChanges();
            }
        }

        public bool Exists(Guid aText)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Texts.Any(textDb => textDb.Id == aText);
            }
            return exists;
        }

        public Text Get(Guid id)
        {
            Text text = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                text = context.Texts.Where(textDb => textDb.Id == id).FirstOrDefault();
            }
            return text;
        }

        public IList<Text> Get()
        {
            IList<Text> texts = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                texts = context.Texts.ToList<Text>();
            }
            return texts;
        }

        public Guid? GetDocumentId(Guid aTextId)
        {
            Guid? documentId;

            using (DocSystDbContext context = new DocSystDbContext())
            {
                var text = context.Texts.Where(textDb => textDb.Id == aTextId).FirstOrDefault();
                var body = context.Bodys.Where(bodyDb => bodyDb.Id == text.BodyId).FirstOrDefault();
                documentId = body.DocumentId;
            }

            return documentId;
        }

        public List<Text> GetTextsInBody(Guid BodyId)
        {
            List<Text> text = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                text = context.Texts.Where(textDb => textDb.BodyId == BodyId).ToList();
            }
            return text;
        }

        public void Modify(Text aText)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Text actualText = context.Texts.FirstOrDefault(textDb => textDb.Id == aText.Id);
                context.Entry(actualText).CurrentValues.SetValues(aText);
                context.SaveChanges();
            }
        }
    }
}

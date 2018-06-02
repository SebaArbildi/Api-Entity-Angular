using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation
{
    public class MarginDataAccess : IMarginDataAccess
    {
        public void Add(Margin aMargin)
        {
            ITextDataAccess textDataAccess = new TextDataAccess();
            foreach(Text text in aMargin.Texts)
            {
                textDataAccess.Add(text);
            }

            using (DocSystDbContext context = new DocSystDbContext())
            {
                aMargin.Texts = AttachTextList(context, aMargin.Texts).ToList();
                context.Margins.Add(aMargin);
                context.SaveChanges();
            }
        }

        public void ClearText(Guid aMargin)
        {
            Margin marginToClear = Get(aMargin);
            marginToClear.ClearText();
            Modify(marginToClear);
        }

        public void Delete(Guid id)
        {
            Margin margin = Get(id);

            using (DocSystDbContext context = new DocSystDbContext())
            {
                List<Text> textList = AttachTextList(context, margin.Texts);
                margin.Texts = textList;
                context.Margins.Attach(margin);
                context.Margins.Remove(margin);
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

        public bool Exists(Guid aMargin)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Margins.Any(marginDb => marginDb.Id == aMargin);
            }
            return exists;
        }

        public Margin Get(Guid id)
        {
            Margin margin = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                margin = context.Margins.Include(marginhDb => marginhDb.Texts)
                                              .FirstOrDefault(marginhDb => marginhDb.Id == id);
            }
            return margin;
        }

        public IList<Margin> Get()
        {
            IList<Margin> margins = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                margins = (context.Margins.Include(marginsDb => marginsDb.Texts)).ToList<Margin>();
            }
            return margins;
        }

        public void Modify(Margin aMargin)
        {
            ITextDataAccess textDataAccess = new TextDataAccess();
            foreach (Text text in aMargin.Texts)
            {
                textDataAccess.Add(text);
            }

            using (DocSystDbContext context = new DocSystDbContext())
            {
                List<Text> textList = AttachTextList(context, aMargin.Texts);
                aMargin.Texts = textList;

                Margin actualMargin = context.Margins.Include(marginhDb => marginhDb.Texts)
                                              .FirstOrDefault(marginhDb => marginhDb.Id == aMargin.Id);

                context.Entry(actualMargin).Entity.Texts = aMargin.Texts;
                context.Entry(actualMargin).CurrentValues.SetValues(aMargin);

                context.SaveChanges();
            }
        }
    }
}

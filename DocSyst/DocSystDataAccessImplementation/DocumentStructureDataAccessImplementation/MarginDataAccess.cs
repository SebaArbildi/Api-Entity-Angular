﻿using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
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
            using (DocSystDbContext context = new DocSystDbContext())
            {
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
                context.Margins.Attach(margin);

                foreach (Text aText in margin.Texts)
                {
                    context.Texts.Attach(aText);
                }

                context.Margins.Remove(margin);
                context.SaveChanges();
            }
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
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Margin actualMargin = context.Margins.Include(marginhDb => marginhDb.Texts)
                                              .FirstOrDefault(marginhDb => marginhDb.Id == aMargin.Id);

                context.Entry(actualMargin).CurrentValues.SetValues(aMargin);
                actualMargin.Texts = aMargin.Texts;

                context.SaveChanges();
            }
        }
    }
}

using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation
{
    public class BodyDataAccess : IBodyDataAccess
    {
        public void Add(Body aBody)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                if(!Exists(aBody.Id))
                {
                    context.Bodys.Add(aBody);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            Body body = Get(id);
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.Bodys.Attach(body);
                context.Bodys.Remove(body);
                context.SaveChanges();
            }
        }

        public bool Exists(Guid aBody)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.Bodys.Any(bodyDb => bodyDb.Id == aBody);
            }
            return exists;
        }

        public Body Get(Guid id)
        {
            Body body = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                body = context.Bodys.Include(bodyhDb => bodyhDb.Texts)
                                              .FirstOrDefault(bodyhDb => bodyhDb.Id == id);
            }
            return body;
        }

        public IList<Body> Get()
        {
            IList<Body> bodys = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                bodys = (context.Bodys.Include(bodysDb => bodysDb.Texts)).ToList<Body>();
            }
            return bodys;
        }

        public void Modify(Body aBody)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                Body actualBody = context.Bodys.Include(bodyhDb => bodyhDb.Texts)
                                              .FirstOrDefault(bodyhDb => bodyhDb.Id == aBody.Id);
                context.Entry(actualBody).CurrentValues.SetValues(aBody);
                context.SaveChanges();
            }
        }
    }
}

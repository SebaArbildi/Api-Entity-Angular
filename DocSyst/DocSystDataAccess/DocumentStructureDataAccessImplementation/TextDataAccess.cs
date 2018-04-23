using System;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.DocumentStructure;

namespace DocSystDataAccess.DocumentStructureDataAccessImplementation
{
    public class TextDataAccess : ITextDataAccess
    {
        public void Add(Text aText)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid aText)
        {
            throw new NotImplementedException();
        }

        public Text Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Text> Get()
        {
            throw new NotImplementedException();
        }

        public void Modify(Text aText)
        {
            throw new NotImplementedException();
        }
    }
}

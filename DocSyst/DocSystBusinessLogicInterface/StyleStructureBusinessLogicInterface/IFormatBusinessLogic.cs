using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface
{
    public interface IFormatBusinessLogic
    {
        void Add(Format format);
        void Delete(Guid id);
        void Modify(Format format);
        IList<Format> Get();
        void AddStyle(Guid formatId, StyleClass styleClass);
        void RemoveStyle(Guid formatId, Guid styleClassId);
        Format Get(Guid id);
    }
}

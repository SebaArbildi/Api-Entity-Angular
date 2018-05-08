using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocSystEntities.StyleStructure;

namespace DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface
{
    public interface IStyleBusinessLogic
    {
        void Add(Style style);
        void Delete(string name);
        void Modify(Style style);
        IList<Style> Get();
        Style Get(string name);
        bool Exists(string name);
    }
}

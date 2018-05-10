using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.ObserverInterface
{
    public interface ISubject
    {
        void AddObserver(StyleClass observer);
        void DeleteObserver(StyleClass observer);
        void NotifyObservers();
    }
}

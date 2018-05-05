using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.ObserverInterface
{
    public interface ISubject
    {
        void Add(IObserver observer);
        void Delete(IObserver observer);
        void Notify();
    }
}

using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.DocumentStructureLogicInterface
{
    public interface IBodyBusinessLogic
    {
        void AddBody(Body newBody);
        void DeleteBody(Guid aBodyId);
        void ModifyBody(Body newBody);
        IList<Body> GetBodys();
        Body GetBody(Guid aBodyId);
    }
}

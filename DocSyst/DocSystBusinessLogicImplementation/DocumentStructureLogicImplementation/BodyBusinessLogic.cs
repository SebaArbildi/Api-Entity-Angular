using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation
{
    public class BodyBusinessLogic : IBodyBusinessLogic
    {
        private IBodyDataAccess bodyDataAccess;

        public BodyBusinessLogic()
        {
        }

        public BodyBusinessLogic(IBodyDataAccess aBodyDataAccess)
        {

        }

        public void AddBody(Body newBody)
        {
            throw new NotImplementedException();
        }

        public void DeleteBody(Guid aBodyId)
        {
            throw new NotImplementedException();
        }

        public Body GetBody(Guid aBodyId)
        {
            throw new NotImplementedException();
        }

        public IList<Body> GetBodys()
        {
            throw new NotImplementedException();
        }

        public void ModifyBody(Body newBody)
        {
            throw new NotImplementedException();
        }
    }
}

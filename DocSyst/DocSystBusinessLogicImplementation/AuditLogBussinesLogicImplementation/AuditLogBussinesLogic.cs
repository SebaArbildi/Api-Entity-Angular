using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystEntities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation
{
    public class AuditLogBussinesLogic : IAuditLogBussinesLogic
    {
        private IAuditLogDataAccess AuditLogDataAccess;
        
        public AuditLogBussinesLogic()
        {
        }

        public AuditLogBussinesLogic(IAuditLogDataAccess auditLogDataAccess)
        {
            AuditLogDataAccess = auditLogDataAccess;
        }

        public void CreateLog(string entityType, Guid entityId, Guid executingUserId, ActionPerformed action)
        {
            AuditLog logEvent = new AuditLog(entityType, entityId, executingUserId, action);
            AuditLogDataAccess.Add(logEvent);
        }

        public bool Exists(Guid id)
        {
            return AuditLogDataAccess.Exists(id);
        }

        public AuditLog GetAuditLog(Guid id)
        {
            return AuditLogDataAccess.Get(id);
        }

        public IList<AuditLog> GetAuditLogs()
        {
            return AuditLogDataAccess.Get();
        }

        public Dictionary<Guid, int> GetLogsPerUserForAnAction(IList<Guid> usersId, DateTime fromDate, DateTime toDate, string entityType, ActionPerformed action)
        {
            Dictionary<Guid, int> entitiesActionedByUser = new Dictionary<Guid, int>();

            foreach (Guid id in usersId)
            {
                IList<AuditLog> logsByOneUser = AuditLogDataAccess.GetLogsPerUserForAnAction(id, fromDate, toDate, entityType, action);
                entitiesActionedByUser.Add(id, logsByOneUser.Count);
            }

            return entitiesActionedByUser;
        }

        public Dictionary<Guid, Dictionary<DateTime, int>> GetLogsPerUserPerDay(IList<Guid> usersId, DateTime fromDate, DateTime toDate, string entityType)
        {

            Dictionary<Guid,Dictionary<DateTime, int>> entitiesActionedPerDayByUser = new Dictionary<Guid, Dictionary<DateTime, int>>();

            foreach(Guid id in usersId)
            {
                IList<IGrouping<DateTime, Guid>> logsByOneUserPerDay = AuditLogDataAccess.GetLogsPerUserPerDay(id, fromDate, toDate, entityType);

                Dictionary<DateTime, int> dateCountPairs = new Dictionary<DateTime, int>();

                foreach(IGrouping<DateTime,Guid> pair in logsByOneUserPerDay)
                {
                    dateCountPairs.Add(pair.Key, pair.Count());
                }

                entitiesActionedPerDayByUser.Add(id, dateCountPairs);
            }

            return entitiesActionedPerDayByUser;
        }
    }
}

using DocSystEntities.Audit;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface
{
    public interface IAuditLogBussinesLogic
    {
        void CreateLog(string entityType, Guid entityId, Guid executingUserId, ActionPerformed action);
        AuditLog GetAuditLog(Guid id);
        IList<AuditLog> GetAuditLogs();
        Dictionary<Guid, Dictionary<DateTime, int>> GetLogsPerUserPerDay(IList<Guid> usersId, DateTime fromDate, DateTime toDate, string entityType);
        Dictionary<Guid, int> GetLogsPerUserForAnAction(IList<Guid> usersId, DateTime fromDate, DateTime toDate, string entityType, ActionPerformed action);
        bool Exists(Guid id);
    }
}

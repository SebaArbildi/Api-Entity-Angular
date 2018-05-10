using DocSystEntities.Audit;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface
{
    public interface IAuditLogBussinesLogic
    {
        void CreateLog(string entityType, Guid? entityId, string executingUserId, ActionPerformed action);
        AuditLog GetAuditLog(Guid id);
        IList<AuditLog> GetAuditLogs();
        Dictionary<string, Dictionary<DateTime, int>> GetLogsPerUserPerDay(IList<string> usersId, DateTime fromDate, DateTime toDate, string entityType);
        Dictionary<string, int> GetLogsPerUserForAnAction(IList<string> usersId, DateTime fromDate, DateTime toDate, string entityType, ActionPerformed action);
        bool Exists(Guid id);
    }
}

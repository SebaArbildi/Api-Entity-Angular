using DocSystEntities.Audit;
using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessInterface.AuditDataAccessInterface
{
    public interface IAuditLogDataAccess
    {
        void Add(AuditLog aAuditLog);
        AuditLog Get(Guid id);
        void Delete(Guid id);
        void Modify(AuditLog aAuditLog);
        IList<AuditLog> Get();
        IList<IGrouping<DateTime, Guid>> GetLogsPerUserPerDay(Guid userId, DateTime fromDate, DateTime toDate, string entityType);
        IList<AuditLog> GetLogsPerUserForAnAction(Guid userId, DateTime fromDate, DateTime toDate, string entityType, ActionPerformed action);
        bool Exists(Guid id);
    }
}

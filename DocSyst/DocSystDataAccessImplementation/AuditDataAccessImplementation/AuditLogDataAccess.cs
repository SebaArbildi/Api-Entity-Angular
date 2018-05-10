using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystEntities.Audit;
using DocSystEntities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystDataAccessImplementation.AuditDataAccessImplementation
{
    public class AuditLogDataAccess : IAuditLogDataAccess
    {
        public void Add(AuditLog aAuditLog)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                context.AuditLogs.Add(aAuditLog);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            AuditLog auditLog = Get(id);
            using (DocSystDbContext conauditLog = new DocSystDbContext())
            {
                conauditLog.AuditLogs.Attach(auditLog);
                conauditLog.AuditLogs.Remove(auditLog);
                conauditLog.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            bool exists = false;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                exists = context.AuditLogs.Any(auditLogDb => auditLogDb.Id == id);
            }
            return exists;
        }

        public AuditLog Get(Guid id)
        {
            AuditLog auditLog = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                auditLog = context.AuditLogs.Where(auditLogDb => auditLogDb.Id == id).FirstOrDefault();
            }
            return auditLog;
        }

        public IList<AuditLog> Get()
        {
            IList<AuditLog> auditLogs = null;
            using (DocSystDbContext context = new DocSystDbContext())
            {
                auditLogs = context.AuditLogs.ToList<AuditLog>();
            }
            return auditLogs;
        }

        public IList<IGrouping<DateTime,Guid>> GetLogsPerUserPerDay(string userId, DateTime fromDate, DateTime toDate, string entityType)
        {
            List<IGrouping<DateTime, Guid>> auditLogs;

            using (DocSystDbContext context = new DocSystDbContext())
            {
                auditLogs = (context.AuditLogs.Where(auditLogDb => auditLogDb.EntityType == entityType)
                                                    .Where(auditLogDb => auditLogDb.OperationDate >= fromDate)
                                                    .Where(auditLogDb => auditLogDb.OperationDate <= toDate)
                                                    .Where(auditLogDb => auditLogDb.ExecutingUserId == userId))
                                                    .GroupBy(auditLogDb => auditLogDb.OperationDate, auditLogDb => auditLogDb.Id)
                                                    .OrderBy(auditLogDb => auditLogDb.Key)
                                                    .ToList();
            }
            return auditLogs;
        }

        public IList<AuditLog> GetLogsPerUserForAnAction(string userId, DateTime fromDate, DateTime toDate, string entityType, ActionPerformed action)
        {
            IList<AuditLog> auditLogs;

            using (DocSystDbContext context = new DocSystDbContext())
            {
                auditLogs = context.AuditLogs.Where(auditLogDb => auditLogDb.EntityType == entityType)
                                                    .Where(auditLogDb => auditLogDb.OperationDate >= fromDate)
                                                    .Where(auditLogDb => auditLogDb.OperationDate <= toDate)
                                                    .Where(auditLogDb => auditLogDb.ExecutingUserId == userId)
                                                    .Where(AuditLogDb => AuditLogDb.Action == action).ToList();
            }
            return auditLogs;
        }

        public void Modify(AuditLog aAuditLog)
        {
            using (DocSystDbContext context = new DocSystDbContext())
            {
                AuditLog actualAuditLog = context.AuditLogs.FirstOrDefault(auditLogDb => auditLogDb.Id == aAuditLog.Id);
                context.Entry(actualAuditLog).CurrentValues.SetValues(aAuditLog);
                context.SaveChanges();
            }
        }
    }
}

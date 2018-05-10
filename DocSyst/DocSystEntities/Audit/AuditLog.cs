using System;
using System.ComponentModel.DataAnnotations;

namespace DocSystEntities.Audit
{
    public enum ActionPerformed
    {
        CREATE,
        MODIFY,
        DELETE,
    }

    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public string EntityType { get; set; }
        public Guid EntityId { get; set; }
        public string ExecutingUserId { get; set; }
        public ActionPerformed Action { get; set; }

        public AuditLog()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.Today.Date;
        }

        public AuditLog(string entityType, Guid entityId, string executingUserId, ActionPerformed action)
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.Today.Date;
            EntityType = entityType;
            EntityId = entityId;
            ExecutingUserId = executingUserId;
            Action = action;
        }

        public override bool Equals(object obj)
        {
            return Id == ((AuditLog)obj).Id;
        }
    }
}

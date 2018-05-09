using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid ExecutingUserId { get; set; }
        public ActionPerformed Action { get; set; }

        public AuditLog()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.Today.Date;
        }

        public AuditLog(string entityType, Guid entityId, Guid executingUserId, ActionPerformed action)
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

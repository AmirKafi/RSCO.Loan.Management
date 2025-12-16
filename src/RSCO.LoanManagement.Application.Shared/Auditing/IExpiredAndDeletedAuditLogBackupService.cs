using System.Collections.Generic;
using Abp.Auditing;

namespace RSCO.LoanManagement.Auditing
{
    public interface IExpiredAndDeletedAuditLogBackupService
    {
        bool CanBackup();
        
        void Backup(List<AuditLog> auditLogs);
    }
}
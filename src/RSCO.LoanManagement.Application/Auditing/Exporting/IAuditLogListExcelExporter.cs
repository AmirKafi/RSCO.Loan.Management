using RSCO.LoanManagement.Auditing.Dto;
using RSCO.LoanManagement.Dto;
using RSCO.LoanManagement.EntityChanges.Dto;
using System.Collections.Generic;

namespace RSCO.LoanManagement.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}

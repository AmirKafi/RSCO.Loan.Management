using System.Collections.Generic;
using Abp;
using RSCO.LoanManagement.Chat.Dto;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}

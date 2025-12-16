using System.Collections.Generic;
using RSCO.LoanManagement.Authorization.Users.Dto;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos, List<string> selectedColumns);
    }
}
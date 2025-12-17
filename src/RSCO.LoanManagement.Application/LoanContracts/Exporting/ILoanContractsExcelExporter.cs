using System.Collections.Generic;
using RSCO.LoanManagement.LoanContracts.Dtos;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.LoanContracts.Exporting
{
    public interface ILoanContractsExcelExporter
    {
        FileDto ExportToFile(List<GetLoanContractForViewDto> loanContracts);
    }
}
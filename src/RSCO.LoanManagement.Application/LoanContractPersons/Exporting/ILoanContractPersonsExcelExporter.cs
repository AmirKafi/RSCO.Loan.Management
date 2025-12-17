using System.Collections.Generic;
using RSCO.LoanManagement.LoanContractPersons.Dtos;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.LoanContractPersons.Exporting
{
    public interface ILoanContractPersonsExcelExporter
    {
        FileDto ExportToFile(List<GetLoanContractPersonForViewDto> loanContractPersons);
    }
}
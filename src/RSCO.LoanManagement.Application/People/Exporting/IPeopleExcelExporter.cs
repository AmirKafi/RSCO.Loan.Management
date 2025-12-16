using System.Collections.Generic;
using RSCO.LoanManagement.People.Dtos;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.People.Exporting
{
    public interface IPeopleExcelExporter
    {
        FileDto ExportToFile(List<GetPersonForViewDto> people);
    }
}
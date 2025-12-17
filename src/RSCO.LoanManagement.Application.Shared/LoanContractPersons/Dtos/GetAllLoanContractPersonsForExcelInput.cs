using Abp.Application.Services.Dto;
using System;

namespace RSCO.LoanManagement.LoanContractPersons.Dtos
{
    public class GetAllLoanContractPersonsForExcelInput
    {
        public string Filter { get; set; }

        public string PersonDisplayPropertyFilter { get; set; }

        public string LoanContractSummeryFilter { get; set; }

    }
}
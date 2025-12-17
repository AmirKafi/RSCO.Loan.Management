using Abp.Application.Services.Dto;
using System;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class GetAllLoanContractsForExcelInput
    {
        public string Filter { get; set; }

        public DateTime? MaxContractDateFilter { get; set; }
        public DateTime? MinContractDateFilter { get; set; }

        public decimal? MaxAmountFilter { get; set; }
        public decimal? MinAmountFilter { get; set; }

        public string SummeryFilter { get; set; }

    }
}
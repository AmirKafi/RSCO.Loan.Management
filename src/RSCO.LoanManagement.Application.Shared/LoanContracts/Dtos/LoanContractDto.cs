using System;
using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class LoanContractDto : EntityDto<Guid>
    {
        public DateTime ContractDate { get; set; }

        public decimal Amount { get; set; }

        public string Summery { get; set; }

    }
}
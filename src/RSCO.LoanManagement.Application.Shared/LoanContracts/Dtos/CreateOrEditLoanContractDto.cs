using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class CreateOrEditLoanContractDto : EntityDto<Guid?>
    {

        public DateTime ContractDate { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string Summery { get; set; }

    }
}
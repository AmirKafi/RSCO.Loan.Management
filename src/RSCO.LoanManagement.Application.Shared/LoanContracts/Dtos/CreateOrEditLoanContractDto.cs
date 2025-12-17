using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class CreateOrEditLoanContractDto : EntityDto<Guid?>
    {

        public DateTime ContractDate { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string Summery { get; set; }

        public Guid? BorrowerId { get; set; }

        public List<Guid> GuarantorIds { get; set; }
    }
}
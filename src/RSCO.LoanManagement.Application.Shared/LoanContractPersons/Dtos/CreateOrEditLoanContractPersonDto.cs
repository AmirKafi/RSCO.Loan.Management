using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.LoanContractPersons.Dtos
{
    public class CreateOrEditLoanContractPersonDto : EntityDto<Guid?>
    {

        public Guid PersonId { get; set; }

        public Guid LoanContractId { get; set; }

    }
}
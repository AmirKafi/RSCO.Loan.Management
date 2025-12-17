using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class GetLoanContractForEditOutput
    {
        public CreateOrEditLoanContractDto LoanContract { get; set; }

    }
}
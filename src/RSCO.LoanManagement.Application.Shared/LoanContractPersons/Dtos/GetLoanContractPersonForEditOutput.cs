using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RSCO.LoanManagement.LoanContractPersons.Dtos
{
    public class GetLoanContractPersonForEditOutput
    {
        public CreateOrEditLoanContractPersonDto LoanContractPerson { get; set; }

        public string PersonDisplayProperty { get; set; }

        public string LoanContractSummery { get; set; }

    }
}
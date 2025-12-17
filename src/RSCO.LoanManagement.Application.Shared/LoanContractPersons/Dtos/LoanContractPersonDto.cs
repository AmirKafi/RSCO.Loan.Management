using System;
using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.LoanContractPersons.Dtos
{
    public class LoanContractPersonDto : EntityDto<Guid>
    {

        public Guid PersonId { get; set; }

        public Guid LoanContractId { get; set; }

    }
}
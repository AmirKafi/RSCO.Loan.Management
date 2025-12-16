using System;
using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.People.Dtos
{
    public class PersonDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
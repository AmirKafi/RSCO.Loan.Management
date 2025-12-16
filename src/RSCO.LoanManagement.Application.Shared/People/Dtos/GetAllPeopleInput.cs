using Abp.Application.Services.Dto;
using System;

namespace RSCO.LoanManagement.People.Dtos
{
    public class GetAllPeopleInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string FirstNameFilter { get; set; }

        public string LastNameFilter { get; set; }

    }
}
using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.People.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
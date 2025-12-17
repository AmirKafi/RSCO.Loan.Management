using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.LoanContracts.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
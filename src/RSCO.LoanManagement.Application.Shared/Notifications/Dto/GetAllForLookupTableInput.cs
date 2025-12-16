using Abp.Application.Services.Dto;

namespace RSCO.LoanManagement.Notifications.Dto
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
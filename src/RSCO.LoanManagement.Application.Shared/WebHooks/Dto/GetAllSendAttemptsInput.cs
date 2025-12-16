using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}

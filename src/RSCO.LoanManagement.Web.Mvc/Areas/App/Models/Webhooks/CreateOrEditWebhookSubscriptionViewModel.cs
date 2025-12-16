using Abp.Application.Services.Dto;
using Abp.Webhooks;
using RSCO.LoanManagement.WebHooks.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}

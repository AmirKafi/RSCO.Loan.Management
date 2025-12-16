using System.Threading.Tasks;
using Abp.Webhooks;

namespace RSCO.LoanManagement.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}

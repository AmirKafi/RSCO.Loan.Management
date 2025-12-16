using System.Threading.Tasks;
using RSCO.LoanManagement.Authorization.Users;

namespace RSCO.LoanManagement.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}

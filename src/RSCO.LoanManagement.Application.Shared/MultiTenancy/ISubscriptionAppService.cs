using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.MultiTenancy.Dto;
using RSCO.LoanManagement.MultiTenancy.Payments.Dto;

namespace RSCO.LoanManagement.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
        
        Task<long> StartExtendSubscription(StartExtendSubscriptionInput input);
        
        Task<StartUpgradeSubscriptionOutput> StartUpgradeSubscription(StartUpgradeSubscriptionInput input);
        
        Task<long> StartTrialToBuySubscription(StartTrialToBuySubscriptionInput input);
    }
}

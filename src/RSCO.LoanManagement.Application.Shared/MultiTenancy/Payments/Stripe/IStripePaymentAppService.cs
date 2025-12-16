using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.MultiTenancy.Payments.Dto;
using RSCO.LoanManagement.MultiTenancy.Payments.Stripe.Dto;

namespace RSCO.LoanManagement.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();
        
        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}
using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.MultiTenancy.Payments.PayPal.Dto;

namespace RSCO.LoanManagement.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}

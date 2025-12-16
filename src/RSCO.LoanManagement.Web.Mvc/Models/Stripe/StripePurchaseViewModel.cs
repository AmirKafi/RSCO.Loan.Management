using RSCO.LoanManagement.MultiTenancy.Payments.Dto;
using RSCO.LoanManagement.MultiTenancy.Payments.Stripe;

namespace RSCO.LoanManagement.Web.Models.Stripe
{
    public class StripePurchaseViewModel
    {
        public SubscriptionPaymentDto Payment { get; set; }
        
        public decimal Amount { get; set; }

        public bool IsRecurring { get; set; }
        
        public bool IsProrationPayment { get; set; }

        public string SessionId { get; set; }

        public StripePaymentGatewayConfiguration Configuration { get; set; }
    }
}

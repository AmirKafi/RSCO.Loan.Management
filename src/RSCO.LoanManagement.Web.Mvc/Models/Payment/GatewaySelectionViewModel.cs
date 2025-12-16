using System.Collections.Generic;
using System.Linq;
using RSCO.LoanManagement.MultiTenancy.Payments;
using RSCO.LoanManagement.MultiTenancy.Payments.Dto;

namespace RSCO.LoanManagement.Web.Models.Payment
{
    public class GatewaySelectionViewModel
    {
        public SubscriptionPaymentDto Payment { get; set; }
        
        public List<PaymentGatewayModel> PaymentGateways { get; set; }

        public bool AllowRecurringPaymentOption()
        {
            return Payment.AllowRecurringPayment() && PaymentGateways.Any(gateway => gateway.SupportsRecurringPayments);
        }
    }
}

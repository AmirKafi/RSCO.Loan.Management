using System.Collections.Generic;

namespace RSCO.LoanManagement.MultiTenancy.Payments
{
    public interface IPaymentGatewayStore
    {
        List<PaymentGatewayModel> GetActiveGateways();
    }
}

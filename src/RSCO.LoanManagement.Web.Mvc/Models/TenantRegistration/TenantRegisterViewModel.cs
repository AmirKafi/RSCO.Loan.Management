using RSCO.LoanManagement.Editions;
using RSCO.LoanManagement.Editions.Dto;
using RSCO.LoanManagement.MultiTenancy.Payments;
using RSCO.LoanManagement.Security;
using RSCO.LoanManagement.MultiTenancy.Payments.Dto;

namespace RSCO.LoanManagement.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public int? EditionId { get; set; }

        public EditionSelectDto Edition { get; set; }
        
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
        
        public SubscriptionStartType? SubscriptionStartType { get; set; }
        
        public PaymentPeriodType? PaymentPeriodType { get; set; }
        
        public string SuccessUrl { get; set; }
        
        public string ErrorUrl { get; set; }
    }
}

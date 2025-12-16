using RSCO.LoanManagement.MultiTenancy.Dto;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Editions
{
    public class SubscriptionDashboardViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        
        public EditionsSelectOutput Editions { get; set; }
    }
}

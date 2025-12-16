using Abp.AutoMapper;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
using Abp.AutoMapper;
using RSCO.LoanManagement.MultiTenancy;
using RSCO.LoanManagement.MultiTenancy.Dto;
using RSCO.LoanManagement.Web.Areas.App.Models.Common;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}
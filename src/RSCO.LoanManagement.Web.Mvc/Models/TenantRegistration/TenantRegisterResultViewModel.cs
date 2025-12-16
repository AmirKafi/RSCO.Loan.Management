using Abp.AutoMapper;
using RSCO.LoanManagement.MultiTenancy.Dto;

namespace RSCO.LoanManagement.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}
using Abp.Auditing;
using RSCO.LoanManagement.Configuration.Dto;

namespace RSCO.LoanManagement.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}
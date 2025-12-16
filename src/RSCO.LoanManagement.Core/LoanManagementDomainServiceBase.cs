using Abp.Domain.Services;

namespace RSCO.LoanManagement
{
    public abstract class LoanManagementDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected LoanManagementDomainServiceBase()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }
    }
}

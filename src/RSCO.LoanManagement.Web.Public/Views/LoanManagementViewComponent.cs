using Abp.AspNetCore.Mvc.ViewComponents;

namespace RSCO.LoanManagement.Web.Public.Views
{
    public abstract class LoanManagementViewComponent : AbpViewComponent
    {
        protected LoanManagementViewComponent()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }
    }
}
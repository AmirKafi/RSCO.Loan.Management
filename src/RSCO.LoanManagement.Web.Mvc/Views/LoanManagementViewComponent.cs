using Abp.AspNetCore.Mvc.ViewComponents;

namespace RSCO.LoanManagement.Web.Views
{
    public abstract class LoanManagementViewComponent : AbpViewComponent
    {
        protected LoanManagementViewComponent()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }
    }
}
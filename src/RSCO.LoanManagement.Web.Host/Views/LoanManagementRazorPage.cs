using Abp.AspNetCore.Mvc.Views;

namespace RSCO.LoanManagement.Web.Views
{
    public abstract class LoanManagementRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected LoanManagementRazorPage()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }
    }
}

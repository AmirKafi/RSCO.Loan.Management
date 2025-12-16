using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace RSCO.LoanManagement.Web.Public.Views
{
    public abstract class LoanManagementRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LoanManagementRazorPage()
        {
            LocalizationSourceName = LoanManagementConsts.LocalizationSourceName;
        }
    }
}

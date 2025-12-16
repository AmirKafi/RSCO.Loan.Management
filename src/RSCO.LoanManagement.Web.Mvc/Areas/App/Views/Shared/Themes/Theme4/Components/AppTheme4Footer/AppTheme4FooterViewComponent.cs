using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Web.Areas.App.Models.Layout;
using RSCO.LoanManagement.Web.Session;
using RSCO.LoanManagement.Web.Views;

namespace RSCO.LoanManagement.Web.Areas.App.Views.Shared.Themes.Theme4.Components.AppTheme4Footer
{
    public class AppTheme4FooterViewComponent : LoanManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme4FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}

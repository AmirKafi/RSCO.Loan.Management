using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Web.Areas.App.Models.Layout;
using RSCO.LoanManagement.Web.Session;
using RSCO.LoanManagement.Web.Views;

namespace RSCO.LoanManagement.Web.Areas.App.Views.Shared.Themes.Theme5.Components.AppTheme5Brand
{
    public class AppTheme5BrandViewComponent : LoanManagementViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme5BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}

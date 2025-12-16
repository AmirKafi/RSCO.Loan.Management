using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Authorization;
using RSCO.LoanManagement.DashboardCustomization;
using System.Threading.Tasks;
using RSCO.LoanManagement.Web.Areas.App.Startup;

namespace RSCO.LoanManagement.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : CustomizableDashboardControllerBase
    {
        public HostDashboardController(
            DashboardViewConfiguration dashboardViewConfiguration,
            IDashboardCustomizationAppService dashboardCustomizationAppService)
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(LoanManagementDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard);
        }
    }
}
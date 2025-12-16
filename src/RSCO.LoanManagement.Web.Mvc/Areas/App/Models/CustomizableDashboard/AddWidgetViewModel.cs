using System.Collections.Generic;
using RSCO.LoanManagement.DashboardCustomization.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}

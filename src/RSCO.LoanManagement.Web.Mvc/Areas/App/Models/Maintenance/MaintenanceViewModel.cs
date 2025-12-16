using System.Collections.Generic;
using RSCO.LoanManagement.Caching.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
        
        public bool CanClearAllCaches { get; set; }
    }
}
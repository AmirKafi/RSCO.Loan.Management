using System.Collections.Generic;
using RSCO.LoanManagement.Editions.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}
using System.Collections.Generic;
using RSCO.LoanManagement.DynamicEntityProperties.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}

using System.Collections.Generic;
using RSCO.LoanManagement.DynamicEntityProperties.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}

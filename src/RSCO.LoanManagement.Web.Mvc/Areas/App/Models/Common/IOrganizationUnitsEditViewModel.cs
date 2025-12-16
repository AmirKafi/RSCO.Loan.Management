using System.Collections.Generic;
using RSCO.LoanManagement.Organizations.Dto;

namespace RSCO.LoanManagement.Web.Areas.App.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}
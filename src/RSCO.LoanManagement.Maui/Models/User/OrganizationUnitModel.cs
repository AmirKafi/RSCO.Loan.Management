using Abp.AutoMapper;
using RSCO.LoanManagement.Organizations.Dto;

namespace RSCO.LoanManagement.Maui.Models.User
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}

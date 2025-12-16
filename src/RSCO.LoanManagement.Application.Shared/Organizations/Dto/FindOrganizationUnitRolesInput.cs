using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Organizations.Dto
{
    public class FindOrganizationUnitRolesInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}

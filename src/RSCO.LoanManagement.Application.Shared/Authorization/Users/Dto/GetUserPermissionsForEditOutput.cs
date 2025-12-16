using System.Collections.Generic;
using RSCO.LoanManagement.Authorization.Permissions.Dto;

namespace RSCO.LoanManagement.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
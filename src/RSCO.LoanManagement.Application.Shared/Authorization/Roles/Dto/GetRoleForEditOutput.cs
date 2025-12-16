using System.Collections.Generic;
using RSCO.LoanManagement.Authorization.Permissions.Dto;

namespace RSCO.LoanManagement.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
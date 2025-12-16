using Abp.Authorization;
using RSCO.LoanManagement.Authorization.Roles;
using RSCO.LoanManagement.Authorization.Users;

namespace RSCO.LoanManagement.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

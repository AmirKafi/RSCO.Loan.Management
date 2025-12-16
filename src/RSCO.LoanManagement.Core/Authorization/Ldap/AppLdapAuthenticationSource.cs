using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using RSCO.LoanManagement.Authorization.Users;
using RSCO.LoanManagement.MultiTenancy;

namespace RSCO.LoanManagement.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
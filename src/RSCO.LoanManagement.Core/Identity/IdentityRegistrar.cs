using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RSCO.LoanManagement.Authentication.TwoFactor.Google;
using RSCO.LoanManagement.Authorization;
using RSCO.LoanManagement.Authorization.Roles;
using RSCO.LoanManagement.Authorization.Users;
using RSCO.LoanManagement.Editions;
using RSCO.LoanManagement.MultiTenancy;

namespace RSCO.LoanManagement.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}

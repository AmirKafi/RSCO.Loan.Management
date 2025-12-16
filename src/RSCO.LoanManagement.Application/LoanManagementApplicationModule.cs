using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RSCO.LoanManagement.Authorization;

namespace RSCO.LoanManagement
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(LoanManagementApplicationSharedModule),
        typeof(LoanManagementCoreModule)
        )]
    public class LoanManagementApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementApplicationModule).GetAssembly());
        }
    }
}
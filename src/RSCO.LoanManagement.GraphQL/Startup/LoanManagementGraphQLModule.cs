using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RSCO.LoanManagement.Startup
{
    [DependsOn(typeof(LoanManagementCoreModule))]
    public class LoanManagementGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}
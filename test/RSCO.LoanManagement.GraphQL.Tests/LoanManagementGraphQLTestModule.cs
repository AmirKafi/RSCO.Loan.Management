using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RSCO.LoanManagement.Configure;
using RSCO.LoanManagement.Startup;
using RSCO.LoanManagement.Test.Base;

namespace RSCO.LoanManagement.GraphQL.Tests
{
    [DependsOn(
        typeof(LoanManagementGraphQLModule),
        typeof(LoanManagementTestBaseModule))]
    public class LoanManagementGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementGraphQLTestModule).GetAssembly());
        }
    }
}
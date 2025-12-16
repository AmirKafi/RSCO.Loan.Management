using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RSCO.LoanManagement
{
    [DependsOn(typeof(LoanManagementCoreSharedModule))]
    public class LoanManagementApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementApplicationSharedModule).GetAssembly());
        }
    }
}
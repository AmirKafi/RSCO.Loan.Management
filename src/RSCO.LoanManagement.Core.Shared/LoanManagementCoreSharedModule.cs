using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RSCO.LoanManagement
{
    public class LoanManagementCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementCoreSharedModule).GetAssembly());
        }
    }
}
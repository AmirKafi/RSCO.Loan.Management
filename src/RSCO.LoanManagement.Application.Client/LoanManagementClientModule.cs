using Abp.Modules;
using Abp.Reflection.Extensions;

namespace RSCO.LoanManagement
{
    public class RSCO.LoanManagementClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RSCO.LoanManagementClientModule).GetAssembly());
        }
    }
}

using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using RSCO.LoanManagement.Configuration;

namespace RSCO.LoanManagement.Test.Base
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(LoanManagementTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}

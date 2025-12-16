using Microsoft.Extensions.Configuration;

namespace RSCO.LoanManagement.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}

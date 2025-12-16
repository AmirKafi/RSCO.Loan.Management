using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.HealthChecks
{
    public class LoanManagementDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public LoanManagementDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("LoanManagementDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("LoanManagementDbContext could not connect to database"));
        }
    }
}

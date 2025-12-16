using Abp.Application.Services;
using RSCO.LoanManagement.Dto;
using RSCO.LoanManagement.Logging.Dto;

namespace RSCO.LoanManagement.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}

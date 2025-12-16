using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.Configuration.Host.Dto;

namespace RSCO.LoanManagement.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}

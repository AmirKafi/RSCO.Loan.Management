using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.Install.Dto;

namespace RSCO.LoanManagement.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}
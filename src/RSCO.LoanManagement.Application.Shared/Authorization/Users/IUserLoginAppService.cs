using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization.Users.Dto;

namespace RSCO.LoanManagement.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
        Task<string> GetExternalLoginProviderNameByUser(long userId);
    }
}

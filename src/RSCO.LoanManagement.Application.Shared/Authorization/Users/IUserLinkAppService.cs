using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Authorization.Users.Dto;

namespace RSCO.LoanManagement.Authorization.Users
{
    public interface IUserLinkAppService : IApplicationService
    {
        Task LinkToUser(LinkToUserInput linkToUserInput);

        Task<PagedResultDto<LinkedUserDto>> GetLinkedUsers(GetLinkedUsersInput input);

        Task<ListResultDto<LinkedUserDto>> GetRecentlyUsedLinkedUsers();

        Task UnlinkUser(UnlinkUserInput input);
    }
}

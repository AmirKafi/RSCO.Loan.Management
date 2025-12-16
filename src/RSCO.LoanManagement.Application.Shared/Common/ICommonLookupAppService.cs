using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RSCO.LoanManagement.Common.Dto;
using RSCO.LoanManagement.Editions.Dto;

namespace RSCO.LoanManagement.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<FindUsersOutputDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}
using System.Threading.Tasks;
using Abp.Application.Services;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}

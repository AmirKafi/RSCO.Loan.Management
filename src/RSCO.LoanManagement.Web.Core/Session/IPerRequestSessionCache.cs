using System.Threading.Tasks;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}

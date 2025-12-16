using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace RSCO.LoanManagement.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}

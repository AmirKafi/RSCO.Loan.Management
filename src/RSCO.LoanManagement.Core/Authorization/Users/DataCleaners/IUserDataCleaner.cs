using Abp;
using System.Threading.Tasks;

namespace RSCO.LoanManagement.Authorization.Users.DataCleaners
{
    public interface IUserDataCleaner
    {
        Task CleanUserData(UserIdentifier userIdentifier);
    }
}

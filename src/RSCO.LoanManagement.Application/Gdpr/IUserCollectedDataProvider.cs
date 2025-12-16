using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using RSCO.LoanManagement.Dto;

namespace RSCO.LoanManagement.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}

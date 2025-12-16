using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Tokens;
using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.OpenIddict.Tokens
{
    public class OpenIddictTokenRepository : EfCoreOpenIddictTokenRepository<LoanManagementDbContext>
    {
        public OpenIddictTokenRepository(
            IDbContextProvider<LoanManagementDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
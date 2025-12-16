using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Scopes;
using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.OpenIddict.Scopes
{
    public class OpenIddictScopeRepository : EfCoreOpenIddictScopeRepository<LoanManagementDbContext>
    {
        public OpenIddictScopeRepository(
            IDbContextProvider<LoanManagementDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
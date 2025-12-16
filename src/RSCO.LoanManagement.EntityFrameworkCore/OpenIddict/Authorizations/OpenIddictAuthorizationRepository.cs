using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Authorizations;
using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.OpenIddict.Authorizations
{
    public class OpenIddictAuthorizationRepository : EfCoreOpenIddictAuthorizationRepository<LoanManagementDbContext>
    {
        public OpenIddictAuthorizationRepository(
            IDbContextProvider<LoanManagementDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
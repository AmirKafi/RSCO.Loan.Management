using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.OpenIddict.EntityFrameworkCore.Applications;
using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.OpenIddict.Applications
{
    public class OpenIddictApplicationRepository : EfCoreOpenIddictApplicationRepository<LoanManagementDbContext>
    {
        public OpenIddictApplicationRepository(
            IDbContextProvider<LoanManagementDbContext> dbContextProvider,
            IUnitOfWorkManager unitOfWorkManager) : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
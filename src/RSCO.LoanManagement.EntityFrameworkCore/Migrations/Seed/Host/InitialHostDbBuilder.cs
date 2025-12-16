using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly LoanManagementDbContext _context;

        public InitialHostDbBuilder(LoanManagementDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}

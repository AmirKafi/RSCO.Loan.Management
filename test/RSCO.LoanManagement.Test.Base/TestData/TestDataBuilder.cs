using RSCO.LoanManagement.EntityFrameworkCore;

namespace RSCO.LoanManagement.Test.Base.TestData
{
    public class TestDataBuilder
    {
        private readonly LoanManagementDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(LoanManagementDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}

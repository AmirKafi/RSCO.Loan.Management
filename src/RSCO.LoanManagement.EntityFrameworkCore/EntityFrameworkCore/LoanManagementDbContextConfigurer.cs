using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RSCO.LoanManagement.EntityFrameworkCore
{
    public static class LoanManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
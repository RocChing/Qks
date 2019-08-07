using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Qks.EntityFrameworkCore
{
    public static class QksDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QksDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QksDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

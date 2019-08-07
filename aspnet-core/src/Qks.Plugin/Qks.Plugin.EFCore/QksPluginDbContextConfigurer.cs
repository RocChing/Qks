using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Qks.Plugin.EFCore
{
    public static class QksPluginDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QksPluginDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QksPluginDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Qks.Plugin.Core;

namespace Qks.Plugin.EFCore
{
    public class QksPluginDbContext : AbpDbContext
    {
        public QksPluginDbContext(DbContextOptions<QksPluginDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Qks.Authorization.Roles;
using Qks.Authorization.Users;
using Qks.MultiTenancy;

using Qks.Code;

namespace Qks.EntityFrameworkCore
{
    public partial class QksDbContext : AbpZeroDbContext<Tenant, Role, User, QksDbContext>
    {
        public DbSet<Table> Tables { get; set; }

        public DbSet<Column> Columns { get; set; }

        public QksDbContext(DbContextOptions<QksDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

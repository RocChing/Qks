using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Qks.Authorization.Roles;
using Qks.Authorization.Users;
using Qks.MultiTenancy;

namespace Qks.EntityFrameworkCore
{
    public partial class QksDbContext : AbpZeroDbContext<Tenant, Role, User, QksDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
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

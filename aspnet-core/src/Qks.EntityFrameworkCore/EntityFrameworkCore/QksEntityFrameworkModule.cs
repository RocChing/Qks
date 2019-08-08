using System;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Qks.EntityFrameworkCore.Seed;

namespace Qks.EntityFrameworkCore
{
    [DependsOn(
        typeof(QksCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class QksEntityFrameworkModule : AbpModule
    {
        public QksEntityFrameworkModule()
        {

        }
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IConnectionStringResolver, IDbPerTenantConnectionStringResolver>()
                        .ImplementedBy<MyDbPerTenantConnectionStringResolver>()
                        .LifestyleTransient()
                    );
            });

            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<QksDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        QksDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        QksDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}

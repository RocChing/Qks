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
        private readonly Type _pluginEFCoreInitType;
        private readonly Plugin.PluginOptions _pluginOpt;
        public QksEntityFrameworkModule(Plugin.PluginOptions pluginOptions)
        {
            //_pluginOpt = pluginOptions;
            //if (_pluginOpt.Loaded) _pluginEFCoreInitType = PluginHelper.GetPluginAssemblyType(QksConsts.Plugin.EFCore, QksConsts.Plugin.EFCoreInit);
        }
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            //Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            //{
            //    IocManager.IocContainer.Register(
            //        Component.For<IConnectionStringResolver>()
            //            .ImplementedBy<MyConnectionStringResolver>()
            //            .LifestyleTransient()
            //        );
            //});
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

                //if (_pluginOpt.Loaded) PluginEFCoreInit();
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksEntityFrameworkModule).GetAssembly());
           // if (_pluginOpt.Loaded) PluginEFCoreRegisterAssembly();
        }

        public override void PostInitialize()
        {
            //if (!SkipDbSeed)
            //{
            //    SeedHelper.SeedHostDb(IocManager);
            //}
        }

        private void PluginEFCoreInit()
        {
            var method = _pluginEFCoreInitType.GetMethod(QksConsts.Plugin.EFCoreInitDbContext);
            method.Invoke(null, new object[] { Configuration });
        }

        private void PluginEFCoreRegisterAssembly()
        {
            var method = _pluginEFCoreInitType.GetMethod(QksConsts.Plugin.EFCoreRegisterAssembly);
            method.Invoke(null, new object[] { IocManager });
        }
    }
}

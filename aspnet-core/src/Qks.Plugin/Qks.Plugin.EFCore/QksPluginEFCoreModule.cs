using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Qks.Plugin.Core;

namespace Qks.Plugin.EFCore
{
    [DependsOn(typeof(QksPluginCoreModule))]
    public class QksPluginEFCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpEfCore().AddDbContext<QksPluginDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    QksPluginDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    QksPluginDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksPluginEFCoreModule).GetAssembly());
        }
    }
}

using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.Plugin.EFCore
{
    public class QksPluginEFCoreInit
    {
        public static void InitDbContext(IAbpStartupConfiguration configuration)
        {
            configuration.Modules.AbpEfCore().AddDbContext<QksPluginDbContext>(options =>
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

        public static void RegisterAssembly(IIocManager iocManager)
        {
            iocManager.RegisterAssemblyByConvention(typeof(QksPluginDbContext).GetAssembly());
        }
    }
}

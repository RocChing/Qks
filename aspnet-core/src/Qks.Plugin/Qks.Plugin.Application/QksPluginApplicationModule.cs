using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Qks.Plugin.Core;
using Abp.AutoMapper;
using Abp.Reflection.Extensions;

namespace Qks.Plugin.Application
{
    [DependsOn(typeof(QksPluginCoreModule), typeof(AbpAutoMapperModule))]
    public class QksPluginApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(QksPluginApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => cfg.AddMaps(thisAssembly));
        }
    }
}

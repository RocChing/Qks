using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Qks.Authorization;

namespace Qks
{
    [DependsOn(
        typeof(QksCoreModule),
        typeof(AbpAutoMapperModule))]
    public class QksApplicationModule : AbpModule
    {
        private readonly Plugin.PluginOptions _pluginOpt;
        public QksApplicationModule(Plugin.PluginOptions pluginOptions)
        {
            _pluginOpt = pluginOptions;
        }
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QksAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QksApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            //if (_pluginOpt.Loaded)
            //{
            //    var pluginAssembly = PluginHelper.GetPluginAssembly(QksConsts.Plugin.Application);
            //    IocManager.RegisterAssemblyByConvention(pluginAssembly);
            //    Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => cfg.AddMaps(pluginAssembly));
            //}

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

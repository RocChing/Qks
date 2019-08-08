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
        public QksApplicationModule()
        {

        }
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QksAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QksApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg => cfg.AddMaps(thisAssembly));
        }
    }
}

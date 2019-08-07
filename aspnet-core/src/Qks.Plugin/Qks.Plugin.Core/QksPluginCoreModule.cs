using Abp.Modules;
using Abp.Reflection.Extensions;
using Qks;

namespace Qks.Plugin.Core
{
    [DependsOn(typeof(QksCoreModule))]
    public class QksPluginCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksPluginCoreModule).GetAssembly());
        }
    }
}

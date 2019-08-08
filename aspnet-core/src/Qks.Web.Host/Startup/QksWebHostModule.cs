using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Qks.Configuration;
using Abp;
using Abp.PlugIns;

namespace Qks.Web.Host.Startup
{
    [DependsOn(typeof(QksWebCoreModule))]
    public class QksWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QksWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksWebHostModule).GetAssembly());
            Logger.Info("ENV_ROC");
            Logger.Info(_env.EnvironmentName);
        }
    }
}

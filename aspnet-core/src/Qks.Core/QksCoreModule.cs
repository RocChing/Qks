using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Qks.Authorization.Roles;
using Qks.Authorization.Users;
using Qks.Configuration;
using Qks.Localization;
using Qks.MultiTenancy;
using Qks.Timing;

namespace Qks
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class QksCoreModule : AbpModule
    {
        private readonly Plugin.PluginOptions _pluginOpt;
        public QksCoreModule(Plugin.PluginOptions pluginOptions)
        {
            _pluginOpt = pluginOptions;
        }
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            QksLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = QksConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksCoreModule).GetAssembly());

            //if (_pluginOpt.Loaded) IocManager.RegisterAssemblyByConvention(PluginHelper.GetPluginAssembly(QksConsts.Plugin.Core));
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

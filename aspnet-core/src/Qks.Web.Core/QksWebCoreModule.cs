using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using Qks.Authentication.JwtBearer;
using Qks.Configuration;
using Qks.EntityFrameworkCore;

namespace Qks
{
    [DependsOn(
         typeof(QksApplicationModule),
         typeof(QksEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        , typeof(AbpAspNetCoreSignalRModule)
     )]
    public class QksWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        private readonly Plugin.PluginOptions _pluginOpt;

        public QksWebCoreModule(IHostingEnvironment env, Plugin.PluginOptions pluginOptions)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
            _pluginOpt = pluginOptions;
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(QksConsts.ConnectionStringName);

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(QksApplicationModule).GetAssembly(), moduleName: QksConsts.Qks);

            if (_pluginOpt.Loaded)
            {
                var pluginAssembly = PluginHelper.GetPluginAssembly(QksConsts.Plugin.Application);

                if (pluginAssembly != null) Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(pluginAssembly, moduleName: QksConsts.Plugin.Name);
            }
            else
            {
                Logger.Error(_pluginOpt.LoadMsg);
            }

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QksWebCoreModule).GetAssembly());
        }
    }
}

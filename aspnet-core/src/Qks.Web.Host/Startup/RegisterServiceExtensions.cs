using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Qks.Utils;
using Qks.Plugin;

namespace Qks.Web.Host.Startup
{
    public static class RegisterServiceExtensions
    {
        public static void RegisterQksService(this IServiceCollection services)
        {
            services.AddTransient(s => new CmdExecutor());
        }

        public static bool RegisterQksPlugin(this IServiceCollection services)
        {
            var pluginOpt = new PluginOptions();
            PluginHelper.LoadPlugins(pluginOpt);
            services.AddSingleton(pluginOpt);
            return pluginOpt.Loaded;
        }
    }
}

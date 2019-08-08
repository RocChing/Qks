using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

using Qks.Utils;
using Qks.Plugin;

namespace Qks.Web.Startup
{
    public static class RegisterServiceExtensions
    {
        public static void RegisterQksService(this IServiceCollection services)
        {
            services.AddTransient(s => new CmdExecutor());
        }

        public static bool RegisterQksPlugin(this IServiceCollection services, IHostingEnvironment hostingEnvironment )
        {
            var pluginOpt = new PluginOptions
            {
                Environment = hostingEnvironment
            };

            PluginHelper.LoadPlugins(pluginOpt);
            services.AddSingleton(pluginOpt);
            return pluginOpt.Loaded;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Qks.Utils;
using Abp.Threading;

namespace Qks.Plugin
{
    public class PluginAppService : QksAppServiceBase, IPluginAppService
    {
        private readonly IApplicationLifetime _app;
        private readonly CmdExecutor _cmd;
        private readonly PluginOptions _pluginOpt;
        public PluginAppService(IApplicationLifetime applicationLifetime, CmdExecutor cmdExecutor, PluginOptions pluginOptions)
        {
            _app = applicationLifetime;
            _cmd = cmdExecutor;
            _pluginOpt = pluginOptions;
        }

        /// <summary>
        /// 插件更新
        /// </summary>
        public void Update()
        {
            _app.ApplicationStopped.Register(BuildProject);

            _app.StopApplication();
        }

        /// <summary>
        /// 增加数据迁移
        /// </summary>
        /// <param name="name">迁移名称(建议英文)</param>
        /// <param name="update">是否更新数据库</param>
        /// <returns></returns>
        public string AddMigrations(string name, bool update = true)
        {
            if (name.IsNullOrEmpty())
            {
                return "迁移名称必输";
            }
            _cmd.ClearArguments();
            _cmd.AddArgument($"cd {_pluginOpt.ProjectPath}");
            _cmd.AddArgument($"dotnet ef -p {QksConsts.Plugin.EFCore} migrations add {name}");
            if (update)
            {
                _cmd.AddArgument($"dotnet ef -p {QksConsts.Plugin.EFCore} database update");
            }
            return _cmd.RunCmdWithOutput2();
        }

        /// <summary>
        /// 移除最近一次数据迁移
        /// </summary>
        /// <param name="update">是否更新数据库</param>
        /// <returns></returns>
        public string RemoveMigrations(bool update = true)
        {
            _cmd.ClearArguments();
            _cmd.AddArgument($"cd {_pluginOpt.ProjectPath}");
            _cmd.AddArgument($"dotnet ef -p {QksConsts.Plugin.EFCore} migrations remove");
            if (update)
            {
                _cmd.AddArgument($"dotnet ef -p {QksConsts.Plugin.EFCore} database update");
            }
            return _cmd.RunCmdWithOutput2();
        }

        private void BuildProject()
        {
            //AsyncHelper.RunSync(() =>
            //{
            //    return Task.CompletedTask;
            //});
            //_cmd.DataReceived = data =>
            //{
            //    Logger.Info(data);
            //};
            _cmd.ClearArguments();
            _cmd.AddArgument($"cd {_pluginOpt.ProjectPath}");
            _cmd.AddArgument($"dotnet build -c Release -o {_pluginOpt.PluginPath}");
            _cmd.RunCmd();
            //string output = _cmd.RunCmdWithOutput2();
            //Logger.Info(output);
        }
    }
}

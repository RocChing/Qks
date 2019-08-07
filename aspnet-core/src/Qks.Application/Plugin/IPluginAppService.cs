using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;

namespace Qks.Plugin
{
    public interface IPluginAppService : IApplicationService
    {
        /// <summary>
        /// 更新插件
        /// </summary>
        void Update();

        string AddMigrations(string name, bool update = true);

        string RemoveMigrations(bool update = true);
    }
}

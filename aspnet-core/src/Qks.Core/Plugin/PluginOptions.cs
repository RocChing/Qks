using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace Qks.Plugin
{
    public class PluginOptions
    {
        /// <summary>
        /// 项目路径
        /// </summary>
        public string ProjectPath { get; set; }

        /// <summary>
        /// 插件路径
        /// </summary>
        public string PluginPath { get; set; }

        /// <summary>
        /// 是否加载成功
        /// </summary>
        public bool Loaded { get; internal set; }

        /// <summary>
        /// 加载结果
        /// </summary>
        public string LoadMsg { get; internal set; }

        /// <summary>
        /// 环境
        /// </summary>
        public IHostingEnvironment Environment { get; set; }

        public PluginOptions()
        {
            ProjectPath = PluginHelper.GetDefaultPluginProjectPath();
            PluginPath = PluginHelper.GetDefaultPluginPath();
            Loaded = false;
        }
    }
}

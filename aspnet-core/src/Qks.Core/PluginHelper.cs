using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.Loader;
using System.Linq;
using Qks.Plugin;
using Abp.Extensions;

namespace Qks
{
    public class PluginHelper
    {
        public static Assembly LoadAssembly(string pluginPath, string fileName)
        {
            string ext = ".dll";
            if (!fileName.EndsWith(ext))
            {
                fileName += ext;
            }

            string path = Path.Combine(pluginPath, fileName);
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

            return assembly;
        }

        public static void LoadPlugins(PluginOptions opt)
        {
            try
            {
                bool flag = CopyFiles(opt.PluginPath);
                //string pluginPath = GetPluginPath();
                //LoadAssembly(pluginPath, QksConsts.Plugin.Core);
                //LoadAssembly(pluginPath, QksConsts.Plugin.Application);
                //LoadAssembly(pluginPath, QksConsts.Plugin.EFCore);
                opt.Loaded = flag;
                opt.LoadMsg = flag ? "插件加载成功" : "没有找到任何插件";
            }
            catch (Exception e)
            {
                opt.LoadMsg = e.ToString();
            }
        }

        public static Assembly GetPluginAssembly(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(m => m.GetName().Name == name);
        }

        public static Type GetPluginAssemblyType(string assemblyName, string typeName)
        {
            var assembly = GetPluginAssembly(assemblyName);
            if (assembly != null)
            {
                return assembly.GetType(typeName, true, true);
            }
            return null;
        }

        public static string GetDefaultPluginPath()
        {
            return Path.Combine(GetProjectParentPath(), QksConsts.Plugin.Plugins);
        }

        public static string GetDefaultPluginProjectPath()
        {
            return Path.Combine(GetProjectParentPath(), QksConsts.Plugin.QksPlugin);
        }

        public static string GetProjectParentPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory).FullName;
        }

        public static string GetPluginPath()
        {
            string destPath = typeof(QksCoreModule).Assembly.Location;
            destPath = Path.Combine(Path.GetDirectoryName(destPath), QksConsts.Plugin.Plugins);
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }
            return destPath;
        }

        public static bool HasPlugin(string path)
        {
            var files = Directory.GetFiles(path, QksConsts.Plugin.AllDll, SearchOption.TopDirectoryOnly);
            return files != null && files.Length > 0;
        }

        private static bool CopyFiles(string sourcePath)
        {
            string destPath = GetPluginPath();

            if (sourcePath.IsNullOrEmpty())
            {
                return HasPlugin(destPath);
            }

            try
            {
                var files = Directory.GetFiles(sourcePath, QksConsts.Plugin.AllDll, SearchOption.TopDirectoryOnly);
                if (files == null || files.Length < 1) return HasPlugin(destPath);

                foreach (var item in files)
                {
                    string fileName = Path.GetFileName(item);
                    if (fileName.StartsWith(QksConsts.QksCore)) continue;
                    File.Copy(item, Path.Combine(destPath, fileName), true);
                }

                foreach (var item in files)
                {
                    File.Delete(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

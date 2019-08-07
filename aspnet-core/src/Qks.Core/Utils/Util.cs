using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Qks.Utils
{
    public static class Util
    {
        public static string GetCombinePath(params string[] paths)
        {
            return Path.Combine(paths);
        }

        public static string GetInnerCombinePath(params string[] paths)
        {
            string path = Environment.CurrentDirectory;
            path = Directory.GetParent(path).FullName;

            if (paths != null && paths.Length > 0)
            {
                foreach (var item in paths)
                {
                    path = Path.Combine(path, item);
                }
            }
            return path;
        }

        public static string GetXmlCommentsPath(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            string fileName = name;
            string ext = ".xml";
            if (!fileName.EndsWith(ext))
            {
                fileName += ext;
            }
            return GetInnerCombinePath(name, fileName);
        }
    }
}

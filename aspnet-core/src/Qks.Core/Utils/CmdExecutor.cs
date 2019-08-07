using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Qks.Utils
{
    public class CmdExecutor
    {
        public CmdExecutor()
        {
            Arguments = new List<string>();
        }

        public Action<string> DataReceived { get; set; }

        public List<string> Arguments { get; private set; }

        public void AddArguments(params string[] args)
        {
            if (args != null && args.Length > 0)
            {
                Arguments.AddRange(args);
            }
        }

        public void AddArgument(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
            {
                Arguments.Add(arg);
            }
        }

        public void ClearArguments()
        {
            Arguments.Clear();
        }

        public void RunCmdWithOutput()
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = GetFileName(); // 命令  
                p.StartInfo.Arguments = string.Join(GetSplitor(), Arguments);    // 参数  

                p.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;  // 重定向输入  
                p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
                p.StartInfo.RedirectStandardError = true;  // 重定向错误输出
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.OutputDataReceived += P_OutputDataReceived; ;
                p.ErrorDataReceived += P_ErrorDataReceived; ;

                p.Start();

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }
        }

        public string RunCmdWithOutput2()
        {
            var output = "";

            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo(GetFileName())
                {
                    Arguments = string.Join(GetSplitor(), Arguments),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                process.Start();

                using (var stdOut = process.StandardOutput)
                {
                    using (var stdErr = process.StandardError)
                    {
                        output = stdOut.ReadToEnd();
                        output += stdErr.ReadToEnd();
                    }
                }
            }
            return output.Trim();
        }

        public void RunCmd()
        {
            var procStartInfo = new ProcessStartInfo(GetFileName(), string.Join(GetSplitor(), Arguments));
            Process.Start(procStartInfo).WaitForExit();
        }

        public void Run(string file, string arguments)
        {
            var procStartInfo = new ProcessStartInfo(file, arguments);
            Process.Start(procStartInfo).WaitForExit();
        }

        private string GetSplitor()
        {
            if (IsWindows()) return ";";
            return "&&";
        }

        //public string GetArguments(string command)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //    {
        //        return "-c \"" + command + "\"";
        //    }

        //    //Windows default.
        //    return "/C \"" + command + "\"";
        //}

        public bool IsWindows()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return false;
            }
            return true;
        }

        public string GetFileName()
        {
            if (IsWindows()) return "powershell.exe";
            else return "/bin/bash";
        }

        private void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            DataReceived?.Invoke(e.Data);
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            DataReceived?.Invoke(e.Data);
        }
    }
}

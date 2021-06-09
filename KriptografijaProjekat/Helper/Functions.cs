using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriptografijaProjekat.Helper
{
    class Functions
    {
        public static String executeCommandReturn(String command)
        {
            var process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", command);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }
    }
}

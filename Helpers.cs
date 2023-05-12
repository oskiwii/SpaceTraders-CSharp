using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spacetraders.Helpers
{
    internal class Helpers
    {
        public static string SetTokenFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string Token = File.ReadAllText(filePath);

                Environment.SetEnvironmentVariable("SPACETRADERS_TOKEN", Token);

                return Token;
            }
            else
            {
                ErrorBox($"Specified file `{filePath}` cannot be found");
                throw new FileNotFoundException($"Specified file `{filePath}` cannot be found");
            }
        }

        public static void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void run_cmd(string cmd)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\C\Desktop\venvs\python\3.9.5\python.exe";
            start.Arguments = string.Format("{0}", cmd);
            start.UseShellExecute = true;
            Console.WriteLine("Starting process...");
            Process p = Process.Start(start);
            p.WaitForExit(100 * 60 * 5);

            while (!p.HasExited) {
                Thread.Sleep(1000);
            }
        }
    }


}

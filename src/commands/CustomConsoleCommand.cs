using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;


namespace KlinoffVault.Commands
{
    public class CustomConsoleCommand
    {
        public static void RunCommand(string[] args)
        {
            args = args.Skip(1).ToArray();
            // run command in cmd
            string command = "";
            foreach (string arg in args)
            {
                command += arg + " ";
            }

            AnsiConsole.MarkupLine("[grey]" + command + "[/]");
            Console.ReadKey();

            // run command in the same console
            var processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = processStartInfo };
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
}
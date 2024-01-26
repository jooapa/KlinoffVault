using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class CustomConsoleCommand
    {
    public static void RunCommand(string[] args)
    {
        // run command in cmd
        string command = "";
        foreach (string arg in args)
        {
            command += arg + " ";
        }
        command = command.TrimEnd(' ');

        // run command in the same console
        var processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = processStartInfo };
        process.OutputDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                Console.WriteLine(e.Data);
            }
        };

        process.Start();
        process.BeginOutputReadLine();

        // Start a task that listens for a key press and then kills the process
        Task.Run(() =>
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (keyInfo.Key != ConsoleKey.Q);  // replace with your key

            process.Kill();
        });
    }
    }
}
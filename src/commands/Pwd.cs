using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Pwd
    {
        public static void ShowPath(string args)
        {
            if (args.Length > 1)
            {
                if (args == "+")
                {
                    AnsiConsole.MarkupLine("[green]" + Start.GetFullAbsoluteCurrentPath() + "[/]");
                    return;
                }
            }
            // show Utils.currentPath
            // string path = Start.GetIsolatedCurrentPath();
            // AnsiConsole.MarkupLine("[green]" + path + "[/]");

            AnsiConsole.MarkupLine("Full Absolute Current Path[green]" + Start.GetFullAbsoluteCurrentPath() + "[/]");
            AnsiConsole.MarkupLine("Isolated Current Path[green]" + Start.GetIsolatedCurrentPath() + "[/]");
            AnsiConsole.MarkupLine("Current Directory[green]" + Directory.GetCurrentDirectory() + "[/]");
        }
    }
}
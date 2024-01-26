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
            if (args.Length > 0)
            {
                if (args == "+")
                {
                    AnsiConsole.MarkupLine("[green]" + Start.GetFullAbsoluteCurrentPath() + "[/]");
                    return;
                }
            }
            // show Utils.currentPath
            string path = Start.GetIsolatedCurrentPath();
            AnsiConsole.MarkupLine("[green]" + path + "[/]");
        }
    }
}
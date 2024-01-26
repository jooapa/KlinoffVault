using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace TakedownOS.Commands
{
    public class Touch
    {
        public static void CreateFile(string file)
        {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Start.GetFullAbsoluteCurrentPath() + file;
            if (File.Exists(path))
            {
                Errors.FileAlreadyExists(Start.GetIsolatedCurrentPath() + file); // isolated path
                return;
            }
            AnsiConsole.MarkupLine("[green]Created file " + Start.GetIsolatedCurrentPath() + file + "[/]");
            File.Create(path);
        }
    }
}
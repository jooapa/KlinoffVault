using System;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace KlinoffVault.Commands
{
    public class Cat
    {
        public static void ShowFile(string file)
        {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), file);

            if (Start.IfFileNotExists(file)) return;

            AnsiConsole.MarkupLine(File.ReadAllText(path));
        }
    }
}
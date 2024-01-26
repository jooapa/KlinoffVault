using System;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace TakedownOS.Commands
{
    public class Cat
    {
        public static void ShowFile(string file)
        {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Start.GetFullAbsoluteCurrentPath() + "\\" + file; // absolute path

            if (Start.IfFileExists(file)) return;

            AnsiConsole.MarkupLine(File.ReadAllText(path));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Vim
    {
        public static void Run(string file) {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Start.GetFullAbsoluteCurrentPath() + "\\" + file;
            
            if (Start.IfFileExists(file)) return;

            AnsiConsole.MarkupLine("[grey]Vim Activated[/]");
        }   
    }
}
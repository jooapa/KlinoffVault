using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using Spectre.Console;

namespace TakedownOS.Commands
{
    public class Ls
    {
        public static void ListFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                AnsiConsole.MarkupLine(file);
            }
        }
    }
}
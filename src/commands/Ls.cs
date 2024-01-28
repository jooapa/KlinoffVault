using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using Spectre.Console;

namespace KlinoffVault.Commands
{
    public class Ls
    {
        public static void ListContent()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            string[] folders = Directory.GetDirectories(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName == "klinoffvault.ini") continue;
                AnsiConsole.MarkupLine("[green]" + fileName + "[/]");
            }
            foreach (string folder in folders)
            {
                string folderName = Path.GetFileName(folder);
                AnsiConsole.MarkupLine("[blue]" + folderName + "[/]");
            }
        }
    }
}
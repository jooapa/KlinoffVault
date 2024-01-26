using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using System.IO;


namespace TakedownOS.Commands
{
    public class OSDirectory
    {
        public static void CreateDirectory(string dir)
        {
            if (Start.IfArgumentEmpty(dir)) return;

            string path = Start.GetFullAbsoluteCurrentPath() + dir;
            if (Directory.Exists(path))
            {
                Errors.DirectoryAlreadyExists(Start.GetIsolatedCurrentPath() + dir); // isolated path
                return;
            }
            AnsiConsole.MarkupLine("[green]Created directory " + Start.GetIsolatedCurrentPath() + dir + "[/]");
            Directory.CreateDirectory(path);
        }

        public static void DeleteDirectory(string dir)
        {
            if (Start.IfArgumentEmpty(dir)) return;

            string path = Start.GetFullAbsoluteCurrentPath() + dir;
            if (Directory.Exists(path) == false)
            {
                Errors.DirectoryDoesntExist(Start.GetIsolatedCurrentPath() + dir); // isolated path
                return;
            }
            try {
                Directory.Delete(path);
                AnsiConsole.MarkupLine("[green]Deleted directory " + Start.GetIsolatedCurrentPath() + dir + "[/]");
            } catch (Exception ex) {
                if (ex.Message.Contains("The directory is not empty")) {
                    AnsiConsole.MarkupLine("[red]Error: Directory is not empty.[/]");
                } else {
                    AnsiConsole.MarkupLine("[red]Error: " + ex.Message + "[/]");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using System.IO;


namespace KlinoffVault.Commands
{
    public class OSDirectory
    {
        public static void CreateDirectory(string dir)
        {
            if (Start.IfArgumentEmpty(dir)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), dir);

            if (Directory.Exists(path))
            {
                Errors.DirectoryAlreadyExists(Path.Combine(Start.GetIsolatedCurrentPath(), dir)); // isolated path
                return;
            }
            AnsiConsole.MarkupLine("[green]Created directory: " + Path.Combine(Start.GetIsolatedCurrentPath(), dir)+ "[/]");
            Directory.CreateDirectory(path);
        }

        public static void DeleteDirectory(string dir)
        {
            if (Start.IfArgumentEmpty(dir)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), dir);
            if (Directory.Exists(path) == false)
            {
                Errors.DirectoryDoesntExist(Path.Combine(Start.GetIsolatedCurrentPath(), dir)); // isolated path
                return;
            }
            try {
                Directory.Delete(path);
                AnsiConsole.MarkupLine("[green]Deleted directory " + Path.Combine(Start.GetIsolatedCurrentPath(), dir) + "[/]");
            } catch (Exception ex) {
                if (ex.Message.Contains("The directory is not empty")) {
                    AnsiConsole.MarkupLine("[red]Error: Directory is not empty.[/]");
                } else {
                    AnsiConsole.MarkupLine("[red]Error: " + ex.Message + "[/]");
                }
            }
        }
        public static void RmRf(string dir)
        {
            // delete directory recursively
            if (Start.IfArgumentEmpty(dir)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), dir);
            if (Directory.Exists(path) == false)
            {
                Errors.DirectoryDoesntExist(Path.Combine(Start.GetIsolatedCurrentPath(), dir)); // isolated path
                return;
            }
            try {
                Directory.Delete(path, true);
                AnsiConsole.MarkupLine("[green]Deleted directory " + Path.Combine(Start.GetIsolatedCurrentPath(), dir) + "[/]");
            } catch (Exception ex) {
                AnsiConsole.MarkupLine("[red]Error: " + ex.Message + "[/]");
            }
        }
    }
}
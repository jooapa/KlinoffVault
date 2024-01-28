using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace KlinoffVault.Commands
{
    public class Touch
    {
        public static void CreateFile(string file)
        {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), file);
            if (File.Exists(path))
            {
                Errors.FileAlreadyExists(Path.Combine(Start.GetIsolatedCurrentPath(),file)); // isolated path
                return;
            }
            AnsiConsole.MarkupLine("[green]Created file " + Path.Combine(Start.GetIsolatedCurrentPath(), file) + "[/]");
            File.Create(path);
        }

        public static void DeleteFile(string file)
        {
            if (Start.IfArgumentEmpty(file)) return;

            string path = Path.Combine(Start.GetFullAbsoluteCurrentPath(), file);
            if (File.Exists(path) == false)
            {
                Errors.FileDoesntExist(Path.Combine(Start.GetIsolatedCurrentPath(), file)); // isolated path
                return;
            }
            try {
                File.Delete(path);
                AnsiConsole.MarkupLine("[green]Deleted file " + Path.Combine(Start.GetIsolatedCurrentPath(), file) + "[/]");
            } catch (Exception ex) {
                AnsiConsole.MarkupLine("[red]Error: " + ex.Message + "[/]");
            }
        }
    }
}
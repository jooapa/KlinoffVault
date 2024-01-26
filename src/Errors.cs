using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace TakedownOS
{
    public class Errors
    {
        public static void NoGoingOutsideOfRootDirectory()
        {
            AnsiConsole.MarkupLine($"[red]Error: You cannot go outside of the root directory![/]");
        }

        public static void DirectoryDoesntExist(string path)
        {
            AnsiConsole.MarkupLine($"[red]Error: Directory '{path}' doesn't exist![/]");
        }

        public static void InvalidCommand(string command)
        {
            AnsiConsole.MarkupLine($"[grey]'[/]{command}[grey]'[/][red] is not recognized as an internal or external command[/]" + 
            "\n" + "Use [grey]'[/][green]help[/][grey]'[/] to see a list of commands");
        }

        public static void FileDoesntExist(string path)
        {
            AnsiConsole.MarkupLine($"[red]Error: File '{path}' doesn't exist![/]");
        }

        public static void NoFileSpecified()
        {
            AnsiConsole.MarkupLine($"[red]Error: No file specified![/]");
        }

        public static void FileAlreadyExists(string path)
        {
            AnsiConsole.MarkupLine($"[red]Error: File '{path}' already exists![/]");
        }

        public static void DirectoryAlreadyExists(string path)
        {
            AnsiConsole.MarkupLine($"[red]Error: Directory '{path}' already exists![/]");
        }
    }
}
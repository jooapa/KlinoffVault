using System;
using System.Threading.Tasks;
using System.Threading;
using Spectre.Console;

namespace TakedownOS
{
    public class Commander
    {
        public static void CheckCommands(string command)
        {
            switch (command)
            {
                case "help":
                    AnsiConsole.MarkupLine("Commands: ");
                    AnsiConsole.MarkupLine("help   Shows this message");
                    AnsiConsole.MarkupLine("clear  Clears the screen");
                    AnsiConsole.MarkupLine("exit   Exits the OS");
                    break;
                case "clear":
                    Commands.Clear.ClearConsole();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    AnsiConsole.MarkupLine($"[grey]'[/]{command}[grey]'[/][red] is not recognized as an internal or external command[/]" + 
                    "\n" + "Use [grey]'[/][green]help[/][grey]'[/] to see a list of commands");
                    break;
            }
        }
    }
}
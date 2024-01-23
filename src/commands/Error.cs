using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Error
    {
        public static void InvalidCommand(string command)
        {
            AnsiConsole.MarkupLine($"[grey]'[/]{command}[grey]'[/][red] is not recognized as an internal or external command[/]" + 
            "\n" + "Use [grey]'[/][green]help[/][grey]'[/] to see a list of commands");
        }
    }
}
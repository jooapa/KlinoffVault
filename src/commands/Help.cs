using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Help
    {
        public static void ShowHelp()
        {
            AnsiConsole.MarkupLine("Commands: ");
            AnsiConsole.MarkupLine("help   Shows this message");
            AnsiConsole.MarkupLine("clear  Clears the screen");
            AnsiConsole.MarkupLine("exit   Exits the OS");
        }
    }
}
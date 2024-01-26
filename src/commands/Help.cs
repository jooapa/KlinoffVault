using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Help
    {
        public static void ShowHelp(string command = "")
        {
            if (command != "") {
                Man(command);
                return;
            }
            
            AnsiConsole.MarkupLine("Commands: ");
            AnsiConsole.MarkupLine("help          Shows this message");
            AnsiConsole.MarkupLine("clear         Clears the screen");
            AnsiConsole.MarkupLine("exit          Exits the OS");
            AnsiConsole.MarkupLine("klinofflang   Runs the Klinofflang interpreter");
            AnsiConsole.MarkupLine("ls            Lists the contents of the current directory");
            AnsiConsole.MarkupLine("cd            Changes the current directory");
            AnsiConsole.MarkupLine("pwd           Shows the current directory");
            AnsiConsole.MarkupLine("cat           Shows the contents of a file");
            AnsiConsole.MarkupLine("vim           Opens the Vim text editor");
        }

        public static void Man(string command)
        {
            switch (command)
            {
                case "help":
                    AnsiConsole.MarkupLine("Shows help message");
                    AnsiConsole.MarkupLine("Usage: help [command]");
                    break;
                case "clear":
                    AnsiConsole.MarkupLine("Clears the screen");
                    AnsiConsole.MarkupLine("Usage: clear");
                    break;
                case "exit":
                    AnsiConsole.MarkupLine("Exits the OS");
                    AnsiConsole.MarkupLine("Usage: exit");
                    break;
                case "klinofflang":
                    AnsiConsole.MarkupLine("Runs the Klinofflang interpreter");
                    AnsiConsole.MarkupLine("Usage: klinofflang [file]");
                    break;
                case "ls":
                    AnsiConsole.MarkupLine("Lists the contents of the current directory");
                    AnsiConsole.MarkupLine("Usage: ls");
                    break;
                case "cd":
                    AnsiConsole.MarkupLine("Changes the current directory");
                    AnsiConsole.MarkupLine("Usage: cd [directory]");
                    break;
                case "pwd":
                    AnsiConsole.MarkupLine("Shows the current directory");
                    AnsiConsole.MarkupLine("Usage: pwd");
                    break;
                case "cat":
                    AnsiConsole.MarkupLine("Shows the contents of a file");
                    AnsiConsole.MarkupLine("Usage: cat [file]");
                    break;
                case "vim":
                    AnsiConsole.MarkupLine("Opens the Vim text editor");
                    AnsiConsole.MarkupLine("Usage: vim [file]");
                    break;
                default:
                    Errors.InvalidCommand(command);
                    break;
            }
        }
    }
}
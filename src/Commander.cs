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
            string cmd = getCommand(command);
            string args = getArgs(command);
            if (!CheckValidCommand(command)) return;

            switch (cmd)
            {
                case "help":
                    Commands.Help.ShowHelp();
                    break;
                case "clear":
                    Commands.Clear.ClearConsole();
                    break;
                case "exit":
                    Commands.Exit.ExitOS();
                    break;
                case "klinofflang":
                    Commands.Klinofflang.RunKlinoff(args);
                    break;
                case "ls":
                    Commands.Ls.ListFiles();
                    break;
                default:
                    Commands.Error.InvalidCommand(command);
                    break;
            }
        }

        public static string getCommand(string command)
        {
            string[] args = command.Split(" ");
            if (args.Length > 0)
            {
                return args[0];
            }
            return "";
        }
        public static string getArgs(string command)
        {
            string[] args = command.Split(" ");
            if (args.Length > 1)
            {
                return args[1];
            }
            return "";
        }
        public static bool CheckValidCommand(string command)
        {
            // remove spaces so, 'space' it doesn't count as a command
            command = command.Replace(" ", "");
            return !string.IsNullOrEmpty(command);
        }
    }
}
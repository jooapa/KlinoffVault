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
            string[] args = command.Split(" ");
            
            if (!CheckValidCommand(args[0])) return;

            // if arg is empty, remove it from array
            if (args.Length > 1)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (string.IsNullOrEmpty(args[i]))
                    {
                        Array.Clear(args, i, 1);
                    }
                }
            }

            switch (args[0])
            {
                case "help":
                    Commands.Help.ShowHelp(args.Length > 1 ? args[1] : "");
                    break;
                case "clear":
                    Commands.Clear.ClearConsole();
                    break;
                case "exit":
                    Commands.Exit.ExitOS();
                    break;
                case "klinofflang":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("klinofflang");;
                        return;
                    }
                    Commands.Klinofflang.RunKlinoff(args[1]);
                    break;
                case "ls":
                    Commands.Ls.ListContent();
                    break;
                case "cd":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("cd");
                        return;
                    }
                    Commands.Cd.ChangeDirectory(args[1]);
                    break;
                case "pwd":
                    if (args.Length == 1) {
                        Commands.Pwd.ShowPath("+");
                        return;
                    }
                    Commands.Pwd.ShowPath(args[1]);
                    break;
                case "cat":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("cat");
                        return;
                    }
                    Commands.Cat.ShowFile(args[1]);
                    break;
                case "vim":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("vim");
                        return;
                    }
                    Commands.Vim.Run(args);
                    break;
                case "touch":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("touch");
                        return;
                    }
                    Commands.Touch.CreateFile(args[1]);
                    break;
                case "console":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("console");
                        return;
                    }
                    Commands.CustomConsoleCommand.RunCommand(args);
                    break;
                case "mkdir":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("mkdir");
                        return;
                    }
                    Commands.OSDirectory.CreateDirectory(args[1]);
                    break;
                case "rmdir":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("rmdir");
                        return;
                    }
                    Commands.OSDirectory.DeleteDirectory(args[1]);
                    break;
                case "rm":
                    if (args.Length == 1) {
                        Commands.Help.ShowHelp("rm");
                        return;
                    }
                    Commands.Touch.DeleteFile(args[1]);
                    break;
                case "user":
                    Folder.CreateEncryptedIni();
                    break;
                case "hide":
                    Commands.Zip.ZipFolder();
                    break;
                default:
                    Errors.InvalidCommand(command);
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
using Spectre.Console;
using System;
using System.Collections.Generic;

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
            AnsiConsole.MarkupLine("touch         Creates a file");
            AnsiConsole.MarkupLine("rm            Deletes a file");
            AnsiConsole.MarkupLine("mkdir         Creates a directory");
            AnsiConsole.MarkupLine("rmdir         Deletes a directory");
            AnsiConsole.MarkupLine("console       Runs a console app");


        }

        public static void Man(string command)
        {
            switch (command)
            {
                case "help":
                    Console.WriteLine("Shows help message");
                    Console.WriteLine("Usage: help [command]");
                    break;
                case "clear":
                    Console.WriteLine("Clears the screen");
                    Console.WriteLine("Usage: clear");
                    break;
                case "exit":
                    Console.WriteLine("Exits the OS");
                    Console.WriteLine("Usage: exit");
                    break;
                case "klinofflang":
                    Console.WriteLine("Runs the Klinofflang interpreter");
                    Console.WriteLine("Usage: klinofflang [file]");
                    break;
                case "ls":
                    Console.WriteLine("Lists the contents of the current directory");
                    Console.WriteLine("Usage: ls");
                    break;
                case "cd":
                    Console.WriteLine("Changes the current directory");
                    Console.WriteLine("Usage: cd [directory]");
                    break;
                case "pwd":
                    Console.WriteLine("Shows the current directory");
                    Console.WriteLine("Usage: pwd");
                    break;
                case "cat":
                    Console.WriteLine("Shows the contents of a file");
                    Console.WriteLine("Usage: cat [file]");
                    break;
                case "vim":
                    Console.WriteLine("Opens the Vim text editor");
                    Console.WriteLine("Usage: vim [file]");
                    break;
                case "touch":
                    Console.WriteLine("Creates a file");
                    Console.WriteLine("Usage: touch [file]");
                    break;
                case "rm":
                    Console.WriteLine("Deletes a file");
                    Console.WriteLine("Usage: rm [file]");
                    break;
                case "mkdir":
                    Console.WriteLine("Creates a directory");
                    Console.WriteLine("Usage: mkdir [directory]");
                    break;
                case "rmdir":
                    Console.WriteLine("Deletes a directory");
                    Console.WriteLine("Usage: rmdir [directory]");
                    break;
                case "console":
                    Console.WriteLine("Runs a console app");
                    Console.WriteLine("Usage: console [app]");
                    break;
                default:
                    Errors.InvalidCommand(command);
                    break;
            }
        }
    }
}
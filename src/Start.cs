using Spectre.Console;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace TakedownOS
{
    public class Start
    {

        public static void Load()
        {
        AnsiConsole.Status()
            .Start("Initializing Quantum Entanglement Drive...", ctx =>
            {
                // Simulate some work
                AnsiConsole.MarkupLine("Calibrating Multidimensional Coordinates...");
                Thread.Sleep(1000);

                // Update the status and spinner
                ctx.Status("Activating Neural Synapses");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));

                // Simulate some work
                AnsiConsole.MarkupLine("Optimizing Code with Quantum Superposition...");
                Thread.Sleep(2000);

                // Update the status and spinner
                ctx.Status("Initializing Quantum Entanglement Driver");
                ctx.Spinner(Spinner.Known.Star2);
                ctx.SpinnerStyle(Style.Parse("blue"));

                // Simulate some work
                AnsiConsole.MarkupLine("Loading TakedownOS...");
                Thread.Sleep(1000);
            });

            Console.Clear();
        }

        public static void CheckArgs(string[] args)
        {
            if (args.Length == 0)
            {
                AnsiConsole.MarkupLine("[red]Error: iso file detected![/]");
                Environment.Exit(1);
            }
            // if first arg isnt folder
            if (Directory.Exists(args[0]) == false)
            {
                AnsiConsole.MarkupLine("[red]Error: First argument must be a folder![/]");
                Environment.Exit(1);
            }

            // in cmd goto to folder
            Directory.SetCurrentDirectory(args[0]);
            // get absolute path
            Utils.AbsolutePathToRoot = Directory.GetCurrentDirectory();
        }
        public static void Run(string[] args)
        {
            CheckArgs(args);
            Console.Clear();
            // load os
            // Load();

            AnsiConsole.Write(
                new FigletText("TakedownOS")
                    .LeftJustified()
                    .Color(Color.SeaGreen1));
            AnsiConsole.MarkupLine("[white]Copyright (C) klinoff-team. All rights reserved.[/]");
            AnsiConsole.MarkupLine("[white]TakedownOS isolated Operating System[/]");

            // AnsiConsole.MarkupLine("[green]Root path set to " + args[0] + "[/]");
            Loop();
        }

        public static void Loop()
        {
            while (true)
            {
                string currentPath = "";
                foreach (string path in Utils.isolatedCurrentPath)
                {
                    currentPath += path + "\\";
                }
                AnsiConsole.Markup("[grey]" + currentPath + ">[/] ");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    Commander.CheckCommands(input);
                }
            }
        }

        public static string GetFullAbsoluteCurrentPath() // returns full absolute path
        {
            return Utils.AbsolutePathToRoot + "\\" + GetIsolatedCurrentPathWithoutRootDir();
        }

        public static string GetIsolatedCurrentPath() // returns isolated path
        {
            string currentPath = "";
            foreach (string path in Utils.isolatedCurrentPath)
            {
                currentPath += path + "\\";
            }
            return currentPath;
        }

        public static string GetIsolatedCurrentPathWithoutRootDir() // returns isolated path without root
        {
            string currentPath = "";
            foreach (string path in Utils.isolatedCurrentPath.Skip(1))
            {
                currentPath += path + "\\";
            }
            return currentPath;
        }

        public static bool IfFileExists(string file)
        {
            string path = GetFullAbsoluteCurrentPath() + "\\" + file;
            if (File.Exists(path) == false)
            {
                Errors.FileDoesntExist(path);
                return true;
            }
            return false;
        }

        public static bool IfArgumentEmpty(string arg)
        {
            if (arg == "")
            {
                Errors.NoFileSpecified();
                return true;
            }
            return false;
        }
    }
}
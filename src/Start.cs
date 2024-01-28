using Spectre.Console;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace KlinoffVault
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
                AnsiConsole.MarkupLine("Loading KlinoffVault...");
                Thread.Sleep(1000);
            });

            Console.Clear();
        }

        public static void Initialize(string[] args)
        {
            if (args.Length == 0)
            {
                AnsiConsole.MarkupLine("[red]Error: no file detected![/]");
                Environment.Exit(1);
            }

            // if file not exists
            if (File.Exists(args[0]) == false && Directory.Exists(args[0]) == false)
            {
                AnsiConsole.MarkupLine("[red]Error: file not exists![/]");
                Environment.Exit(1);
            }

            // if first arg TDOS file
            if (IsTDOSFile(args[0]))
            {
                if (CheckIfDirectoryAlreadyExistsInParent(args[0].Replace(".kv", ""))) {
                    Environment.Exit(1);
                }

                // ASK for password and key and IV
                string password = AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter: " + args[0] + " password:")
                        .Secret()
                );


                byte[] encryptedPassword = Crypt.EncryptString(password, Crypt.GetIVandKey(password).Item1, Crypt.GetIVandKey(password).Item2);
                string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);

                // AnsiConsole.MarkupLine("[green]password: " + encryptedPasswordString + "[/]");
                // decrypt zip file
                Commands.Zip.UnzipFolder(encryptedPasswordString, args[0]);
                Directory.SetCurrentDirectory(args[0].Replace(".kv", ""));
            }
            // if first arg is folder
            else if (Directory.Exists(args[0]))
            {
                Directory.SetCurrentDirectory(args[0]);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Error: no file detected![/]");
                Environment.Exit(1);
            }

            // if has more than 1 arg
            if (args.Length == 2)
            {
                if (args[1] == "-exe")
                {
                    // path to executable
                    Utils.klinoffInterpiterPath = System.AppDomain.CurrentDomain.BaseDirectory;
                }
                else if (args[1] == "-run")
                {
                    // path to executable
                    Utils.klinoffInterpiterPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Error: second argument must be -exe or -run![/]");
                    AnsiConsole.MarkupLine("[red]'-exe' klinoff Interpiter in the exe folder, if running from exe[/]");
                    AnsiConsole.MarkupLine("[red]'-run' klinoff Interpiter in the root folder, if running from source[/]");
                    Environment.Exit(1);
                }
            }
            else
            {
                Utils.klinoffInterpiterPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            }

            // get absolute path
            Utils.absolutePathToRoot = Directory.GetCurrentDirectory();        
            (string systemName, string systemPassword) = Folder.SetupCreateEncryptedIni();
            Folder.CreateEncryptedIni(systemName, systemPassword);
        }
        public static void Run(string[] args)
        {
            Console.Clear();
            Console.Title = "KlinoffVault";
            AnsiConsole.WriteLine("\n");
            Initialize(args);
            Console.Clear();
            // load os
            // Load();

            AnsiConsole.Write(
                new FigletText("KlinoffVault")
                    .LeftJustified()
                    .Color(Color.SeaGreen1));
            AnsiConsole.MarkupLine("[white]Copyright (C) klinoff-team. All rights reserved.[/]");
            AnsiConsole.MarkupLine("[white]KlinoffVault isolated Operating System[/]\n");

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

        public static bool CheckIfDirectoryAlreadyExistsInParent(string dir)
        {
            string parentPath = Directory.GetCurrentDirectory();
            string path = Path.Combine(parentPath, dir);
            if (Directory.Exists(path))
            {
                Errors.DirectoryAlreadyExists(dir);
                return true;
            }
            return false;
        }

        public static bool IsTDOSFile(string file)
        {
            if (file.EndsWith(".kv") == false)
            {
                return false;
            }
            return true;
        }

        public static string GetFullAbsoluteCurrentPath() // returns full absolute path
        {
            return Path.Combine(Utils.absolutePathToRoot, GetIsolatedCurrentPathWithoutRootDir());
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

        public static bool IfFileNotExists(string file)
        {
            string path = Path.Combine(GetFullAbsoluteCurrentPath(), file);
            if (File.Exists(path) == false)
            {
                Errors.FileDoesntExist(Path.Combine(GetIsolatedCurrentPath(), file));
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
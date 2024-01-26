using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Vim
    {
        public static void Run(string[] args)
        {
            if (args.Length == 1)
            {
                AnsiConsole.MarkupLine("[red]Error: No file specified.[/]");
                return;
            }
            
            if (Start.IfArgumentEmpty(args[1])) return;

            string path = args[1];
            List<string> lines = new List<string>();
            
            Clear.ClearConsole();
            AnsiConsole.MarkupLine("[green]Enter text. Type only :wq to line to save and quit.[/]");

            while (true)
            {
                string? line = Console.ReadLine();

                if (line == ":wq")
                {
                    break;
                }

                if (line != null)
                {
                    lines.Add(line);
                }
            }

            try
            {
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Error writing to file:[/] " + ex.Message);
            }
        }
    }
}
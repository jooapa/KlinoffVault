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

        public static void Run()
        {
            Console.Clear();
            // load os
            // Load();

            AnsiConsole.Write(
                new FigletText("TakedownOS")
                    .LeftJustified()
                    .Color(Color.SeaGreen1));
            
            Loop();
        }

public static void Loop()
{
    while (true)
    {
        AnsiConsole.Markup("[grey]TakedownOS" + Utils.currentPath + ">[/] ");
        string? input = Console.ReadLine();
        if (input != null)
        {
            Commander.CheckCommands(input);
        }
    }
}
    }
}
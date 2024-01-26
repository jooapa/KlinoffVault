using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using Spectre.Console;

namespace TakedownOS.Commands
{
    public class Klinofflang
    {
        public static void RunKlinoff(string arg) {
            if (arg == "help") {
                AnsiConsole.MarkupLine("[green]Klinofflang is a programming language that is based on the Klinoff language.[/]");
                AnsiConsole.MarkupLine("It is a very simple language, and is not meant to be used for anything serious.");
            }


        }
    }
}
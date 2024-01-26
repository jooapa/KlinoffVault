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
        public static void RunKlinoff(string file) {
            // get the path where command is executed
            string path = Utils.klinoffInterpiterPath + "\\klinoff Interpeter\\interpret.py";

            // check if file exists
            if (Start.IfFileNotExists(file)) return;
            file = Start.GetFullAbsoluteCurrentPath() + file;

            CustomConsoleCommand.RunCommand(new string[] { "d", "python3 \"" + path + "\" \"" + file + "\"" });
    
        }
    }
}
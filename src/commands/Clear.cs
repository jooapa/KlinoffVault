using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinoffVault.Commands
{
    public class Clear
    {
        public static void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    }
}
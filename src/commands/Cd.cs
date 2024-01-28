using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace KlinoffVault.Commands
{
    public class Cd
    {
        public static void ChangeDirectory(string path)
        {
            if (path == "..")
            {
                if (Utils.isolatedCurrentPath.Length == 1)
                {
                    Errors.NoGoingOutsideOfRootDirectory();
                    return;
                }
                // remove last item from array and set as current path
                Utils.isolatedCurrentPath = Utils.isolatedCurrentPath.Take(Utils.isolatedCurrentPath.Count() - 1).ToArray();
                // set current directory to the array but without the first item
                Environment.CurrentDirectory = Utils.absolutePathToRoot + "\\" + string.Join("\\", Utils.isolatedCurrentPath.Skip(1).ToArray());
                return;
            }

            if (path == ".")
            {
                return;
            }

            if (path == "/" || path == "\\")
            {
                Environment.CurrentDirectory = Utils.absolutePathToRoot;
                Utils.isolatedCurrentPath = new string[] { Utils.isolatedRoot };
                return;
            }

            // loop through all folders in current directory
            if (CheckIfDirectoryExistsInCurrentDirectory(path) == false)
            {
                Errors.DirectoryDoesntExist(path);
                return;
            }

            Environment.CurrentDirectory = path;
            //push to array
            Utils.isolatedCurrentPath = Utils.isolatedCurrentPath.Concat(new string[] { path }).ToArray();
            
        }

        public static bool CheckIfDirectoryExistsInCurrentDirectory(string path)
        {
            string[] directories = Directory.GetDirectories(Environment.CurrentDirectory);
            foreach (string directory in directories)
            {
                // relative path
                if (directory == Path.Combine(Environment.CurrentDirectory, path))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
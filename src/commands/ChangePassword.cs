using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class ChangePassword
    {
        public static void ChangeIt()
        {
            Directory.SetCurrentDirectory(Utils.absolutePathToRoot);
            File.Delete("takedown.ini");

            (string systemName, string password) = Folder.CreateEncryptedIni();

            string parentFolderPath = Directory.GetParent(Utils.absolutePathToRoot).FullName;
            Directory.SetCurrentDirectory(parentFolderPath);

            // rename folder to sysname
            string folderPath = Utils.absolutePathToRoot;
            string newFolderPath = Path.Combine(parentFolderPath, systemName);

            if (!Directory.Exists(newFolderPath))
            {
                Directory.Move(folderPath, newFolderPath);
            }
            else
            {
                // Handle the case when the destination directory already exists
                // You can choose to throw an exception, display an error message, or take any other appropriate action
                Console.WriteLine("Destination directory already exists.");
            }

            // change directory to new folder
            Directory.SetCurrentDirectory(newFolderPath);
            Utils.absolutePathToRoot = Directory.GetCurrentDirectory();
            Utils.isolatedCurrentPath = new string[] { Utils.isolatedRoot };
        }
    }
}
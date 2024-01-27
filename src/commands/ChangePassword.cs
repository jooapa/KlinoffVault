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
            File.Delete("takedown.ini");

            Folder.CreateEncryptedIni();

            string parentFolderPath = Directory.GetParent(Utils.absolutePathToRoot).FullName;
            Directory.SetCurrentDirectory(parentFolderPath);
            (string systemName, string password) = Folder.GetIniData();
            // rename folder to sysname
            string folderPath = Utils.absolutePathToRoot;
            string newFolderPath = Path.Combine(parentFolderPath);

            AnsiConsole.MarkupLine("from: " + folderPath + " to: " + newFolderPath);

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
        }
    }
}
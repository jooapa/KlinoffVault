using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace KlinoffVault.Commands
{
    public class ChangePassword
    {
        public static void ChangeIt()
        {
            Directory.SetCurrentDirectory(Utils.absolutePathToRoot);
            (string oldSystemName, string oldPassword) = Folder.GetIniData();
            File.Delete("klinoffvault.ini");

            (string systemName, string password) = Folder.SetupCreateEncryptedIni();

            string parentFolderPath = Directory.GetParent(Utils.absolutePathToRoot).FullName;
            Directory.SetCurrentDirectory(parentFolderPath);

            // change directory to new folder
            Directory.SetCurrentDirectory(systemName);
            Utils.absolutePathToRoot = Directory.GetCurrentDirectory();
            Utils.isolatedCurrentPath = new string[] { Utils.isolatedRoot };
        }
    }
}
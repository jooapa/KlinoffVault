using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Spectre.Console;


namespace TakedownOS.Commands
{
    public class Zip
    {
        public static void ZipFolder()
        {
            (string systemName, string password) = Folder.GetIniData();

            string folderPath = Utils.absolutePathToRoot;
            string parentFolderPath = Directory.GetParent(folderPath).FullName;
            string zipFilePath = Path.Combine(parentFolderPath, systemName + ".zip");
            
            ZipFile.CreateFromDirectory(folderPath, zipFilePath);

            string encryptedZipFilePath = Path.Combine(parentFolderPath, systemName + ".tdos");

            // encrypt zip file
            Crypt.EncryptFile(zipFilePath, encryptedZipFilePath, password);
            // delete zip file
            File.Delete(zipFilePath);
            RmRfFolder(folderPath);
        }

        public static void RmRfFolder(string folderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }

        public static void UnzipFolder(string password, string foldername)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string parentFolderPath = Directory.GetCurrentDirectory();
            // get folder name using .net
            foldername = Path.GetFileName(foldername);
            string zipFilePath = Path.Combine(parentFolderPath, foldername);

            string incomingFolderName = Path.Combine(currentPath, foldername.Replace(".tdos", ".zip"));
            string folderPath = Path.Combine(currentPath, foldername.Replace(".tdos", ""));
            // decrypt zip file
            Crypt.DecryptFile(zipFilePath, incomingFolderName, password);

            AnsiConsole.MarkupLine("[green]Password correct![/]");
            // unzip file
            AnsiConsole.MarkupLine("[green]Unzipping from " + incomingFolderName + " to " + folderPath + "[/]");
            ZipFile.ExtractToDirectory(incomingFolderName, folderPath);
            // delete zip file
            File.Delete(incomingFolderName);
            File.Delete(foldername);
        }

    }
}
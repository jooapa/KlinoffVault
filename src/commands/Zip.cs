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
            // encrypt zip file
            EncyptZipFile(zipFilePath, password);
        }

        public static void UnzipFolder(string password, string foldername)
        {
            string folderPath = Directory.GetCurrentDirectory();
            string parentFolderPath = Directory.GetCurrentDirectory();
            // get folder name using .net
            foldername = Path.GetFileName(foldername);
            string zipFilePath = Path.Combine(parentFolderPath, foldername);

            foldername = foldername.Replace(".zip", "");
            string incomingFolderName = Path.Combine(folderPath, foldername);
            // decrypt zip file
            DecryptZipFile(zipFilePath, password);
            // unzip file
            ZipFile.ExtractToDirectory(zipFilePath, incomingFolderName);
            // delete zip file
            File.Delete(zipFilePath);
        }

        public static void EncyptZipFile(string zipFilePath, string password)
        {
            Crypt.EncryptFile(zipFilePath, password);
        }

        public static void DecryptZipFile(string zipFilePath, string password)
        {
            Crypt.DecryptFile(zipFilePath, password);
        }
    }
}
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

            string incomingFolderName = Path.Combine(folderPath, foldername);
            // decrypt zip file
            DecryptZipFile(zipFilePath, password);
            // unzip file
            ZipFile.ExtractToDirectory(zipFilePath, incomingFolderName);
        }
        public static void EncyptZipFile(string zipFilePath, string password)
        {
            // read zip file
            string zipFileBytes = File.ReadAllText(zipFilePath);
            // KEYS
            (byte[] keyBytes , byte[] IVBytes) = Crypt.GetIVandKey(password);
            if (IVBytes.Length != 16)
            {
                throw new Exception("Invalid IV size. IV must be 128 bits.");
            }
            // encrypt zip file
            byte[] encryptedZipFileBytes = Crypt.Encrypt(zipFileBytes, keyBytes, IVBytes);
            // write encrypted zip file
            File.WriteAllBytes(zipFilePath, encryptedZipFileBytes);
        }

        public static void DecryptZipFile(string zipFilePath, string password)
        {
            // read zip file
            byte[] encryptedZipFileBytes = File.ReadAllBytes(zipFilePath);
            // KEYS
            (byte[] keyBytes , byte[] IVBytes) = Crypt.GetIVandKey(password);
            if (IVBytes.Length != 16)
            {
                throw new Exception("Invalid IV size. IV must be 128 bits.");
            }
            AnsiConsole.MarkupLine($"[red]Decrypting {zipFilePath} with {password}[/]");
            // decrypt zip file
            string decryptedZipFileBytes = Crypt.Decrypt(encryptedZipFileBytes, keyBytes, IVBytes);
            // write decrypted zip file
            File.WriteAllText(zipFilePath, decryptedZipFileBytes);
        }
    }
}
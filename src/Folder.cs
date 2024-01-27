using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using Spectre.Console;

namespace TakedownOS
{
    public class Folder
    {
        public static void MakeFolder()
        {
            
        }

        public static void DeleteFolder()
        {
            
        }

        public static void encryptFolder()
        {
            
        }

        public static void decryptFolder()
        {
            
        }

        public static bool CheckIfIniFileExists()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName == "takedown.ini")
                {
                    return true;
                }
            }
            return false;
        }

        public static void CreateIniFile()
        {
            if (CheckIfIniFileExists() == true) return;

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter password: ")
                    .Secret()
            );
            
            (byte[] encrypted, byte[] key, byte[] IV) = Crypt.EncryptAesManaged(password);
            string encryptedString = Convert.ToBase64String(encrypted);
            string keyString = Convert.ToBase64String(key);
            string IVString = Convert.ToBase64String(IV);

            string iniContent = $"{encryptedString}\n{keyString}\n{IVString}";
            File.WriteAllText("takedown.ini", iniContent);

        }


    }
}
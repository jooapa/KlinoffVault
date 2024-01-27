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

        public static void CreateEncryptedIni()
        {
            if (CheckIfIniFileExists() == true) return;
            
            string name = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter System name:")
            );

            string password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter Secure password:")
                    .Secret()
            );
            
            byte[] encrypted = Crypt.Encrypt(name, Crypt.GetIVandKey(password).Item1, Crypt.GetIVandKey(password).Item2);
            string encryptedString = Convert.ToBase64String(encrypted);

            string iniContent = $"{name}\n{encryptedString}";
            File.WriteAllText("takedown.ini", iniContent);

        }

        public static (string, string) GetIniData()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName == "takedown.ini")
                {
                    string[] lines = File.ReadAllLines(file);
                    return (lines[0], lines[1]);
                }
            }
            return ("", "");
        }
    }
}
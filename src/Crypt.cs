using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Spectre.Console;


class Crypt {

    private const int Iterations = 10000;
    private const int KeySize = 256;

    public static void EncryptFile(string inputFile, string outputFile, string password)
    {
        try {
            using (AesManaged aesAlg = new AesManaged())
            {
                byte[] salt = GenerateRandomSalt();

                using (Rfc2898DeriveBytes keyDerivationFunction = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    aesAlg.Key = keyDerivationFunction.GetBytes(KeySize / 8);
                    aesAlg.IV = keyDerivationFunction.GetBytes(aesAlg.BlockSize / 8);
                }

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(fsOutput, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        fsOutput.Write(salt, 0, salt.Length);

                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            csEncrypt.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        } catch (Exception exp) {
            AnsiConsole.MarkupLine($"[red]Error: {exp.Message}[/]");
            Environment.Exit(1);
        }
    }

    public static void DecryptFile(string inputFile, string outputFile, string password, bool isZip = false)
    {
        try {
            using (AesManaged aesAlg = new AesManaged())
            {
                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                {
                    byte[] salt = new byte[16];
                    fsInput.Read(salt, 0, salt.Length);

                    using (Rfc2898DeriveBytes keyDerivationFunction = new Rfc2898DeriveBytes(password, salt, Iterations))
                    {
                        aesAlg.Key = keyDerivationFunction.GetBytes(KeySize / 8);
                        aesAlg.IV = keyDerivationFunction.GetBytes(aesAlg.BlockSize / 8);
                    }

                    using (CryptoStream csDecrypt = new CryptoStream(fsOutput, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            csDecrypt.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        } catch (Exception exp) {
            if (exp.Message == "Padding is invalid and cannot be removed.") {
                AnsiConsole.MarkupLine("[red]Error: Password incorrect![/]");
                if (isZip) {
                    // replace .kv with .zip
                    string zipFilePath = inputFile.Replace(".kv", ".zip");
                    // delete zip file
                    File.Delete(zipFilePath);
                }
                Environment.Exit(1);
            }
            AnsiConsole.MarkupLine($"[red]Error: {exp.Message}[/]");
            Environment.Exit(1);
        }
    }

    private static byte[] GenerateRandomSalt()
    {
        byte[] salt = new byte[16];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetBytes(salt);
        }
        return salt;
    }
    public static void TestCommand() {
        // Encrypt the string to an array of bytes.
        byte[] encrypted = EncryptString("Hello World!", GetIVandKey("password").Item1, GetIVandKey("password").Item2);
        // Decrypt the bytes to a string.
        byte[] decrypted = Decrypt(encrypted, GetIVandKey("password").Item1, GetIVandKey("password").Item2);
        // Display the original data and the decrypted data.
        Console.WriteLine($"Original:   {Encoding.UTF8.GetString(encrypted)}");
        Console.WriteLine($"Round Trip: {Encoding.UTF8.GetString(decrypted)}");
    }

    public static string TestEncrypt(string plainText, string password) {
        // Encrypt the string to an array of bytes.
        byte[] encrypted = EncryptString(plainText, GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        return Convert.ToBase64String(encrypted);
    }

    public static string TestDecrypt(string encrypted, string password) {
        // Decrypt the bytes to a string.
        byte[] decrypted = Decrypt(Convert.FromBase64String(encrypted), GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        return Encoding.UTF8.GetString(decrypted);
    }

    public static byte[] EncryptString(string plainText, byte[] Key, byte[] IV) {
        byte[] encrypted;
        using(Aes aes = Aes.Create()) {
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            using(MemoryStream ms = new MemoryStream()) {
                using(CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
                    using(StreamWriter sw = new StreamWriter(cs))
                        sw.Write(plainText);
                }
                encrypted = ms.ToArray();
                ms.Flush();
            }
        }
        return encrypted;
    }

    public static byte[] Encrypt(byte[] plainText, byte[] Key, byte[] IV) {
        byte[] encrypted;
        using(Aes aes = Aes.Create()) {
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            using(MemoryStream ms = new MemoryStream()) {
                using(CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
                    cs.Write(plainText, 0, plainText.Length);
                }
                encrypted = ms.ToArray();
                ms.Flush();
            }
        }
        return encrypted;
    }
    public static byte[] Decrypt(byte[] cipherText, byte[] Key, byte[] IV) {
        try {
            byte[] decrypted;
            using (Aes aes = Aes.Create()) {
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cipherText)) {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
                        using (MemoryStream resultStream = new MemoryStream()) {
                            cs.CopyTo(resultStream);
                            decrypted = resultStream.ToArray();
                        }
                    }
                }
            }
            return decrypted;
        } catch (Exception exp) {
            AnsiConsole.MarkupLine($"[red]Error: {exp.Message}[/]");
            return null;
        }
    }
    private static readonly byte[] saltBytes = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8 };
    private const int iterations = 10000;

    public static (byte[], byte[]) GetIVandKey(string password) {
        using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations, HashAlgorithmName.SHA256)) {
            byte[] key = deriveBytes.GetBytes(32); // 256 bits for AES 256
            byte[] iv = deriveBytes.GetBytes(16);  // 128 bits for AES
            return (key, iv);
        }
    }
}
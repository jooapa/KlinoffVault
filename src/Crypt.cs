using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Spectre.Console;


class Crypt {
    public static void TestCommand() {
        // Encrypt the string to an array of bytes.
        byte[] encrypted = Encrypt("Hello World!", GetIVandKey("password").Item1, GetIVandKey("password").Item2);
        // Decrypt the bytes to a string.
        byte[] decrypted = Decrypt(encrypted, GetIVandKey("password").Item1, GetIVandKey("password").Item2);
        // Display the original data and the decrypted data.
        Console.WriteLine($"Original:   {Encoding.UTF8.GetString(encrypted)}");
        Console.WriteLine($"Round Trip: {Encoding.UTF8.GetString(decrypted)}");
    }

    public static string TestEncrypt(string plainText, string password) {
        // Encrypt the string to an array of bytes.
        byte[] encrypted = Encrypt(plainText, GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        return Convert.ToBase64String(encrypted);
    }

    public static string TestDecrypt(string encrypted, string password) {
        // Decrypt the bytes to a string.
        byte[] decrypted = Decrypt(Convert.FromBase64String(encrypted), GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        return Encoding.UTF8.GetString(decrypted);
    }

    public static void EncryptFile(string filePath, string password) {
        // Encrypt the string to an array of bytes.
        byte[] encrypted = Encrypt(File.ReadAllText(filePath), GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        File.WriteAllBytes(filePath, encrypted);
    }

    public static void DecryptFile(string filePath, string password) {
        // Decrypt the bytes to a string.
        byte[] decrypted = Decrypt(File.ReadAllBytes(filePath), GetIVandKey(password).Item1, GetIVandKey(password).Item2);
        // Display the original data and the decrypted data.
        File.WriteAllBytes(filePath, decrypted);
    }

    public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV) {
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
            Environment.Exit(1);
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
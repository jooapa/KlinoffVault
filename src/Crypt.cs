using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Spectre.Console;


class Crypt {
    public static (byte[], byte[], byte[]) EncryptAesManaged(string raw) {
        try {
            // Create Aes that generates a new key and initialization vector (IV).
            // Same key must be used in encryption and decryption
            using(Aes aes = Aes.Create()) {
                // Encrypt string
                byte[] encryptedBytes = Encrypt(raw, aes.Key, aes.IV);

                return (encryptedBytes, aes.Key, aes.IV);
            }
        } catch (Exception exp) {
            AnsiConsole.MarkupLine($"[red]Error: {exp.Message}[/]");
        }
        return (null, null, null);
    }

    public static string DecryptAesManaged(string encrypted, byte[] key, byte[] IV) {
        try {
            // Create Aes that generates a new key and initialization vector (IV).
            // Same key must be used in encryption and decryption
            using(Aes aes = Aes.Create()) {
                // Convert encrypted string to byte array
                byte[] encryptedBytes = Convert.FromBase64String(encrypted);
                // Decrypt bytes
                string decrypted = Decrypt(encryptedBytes, key, IV);

                return decrypted;
            }
        } catch (Exception exp) {
            AnsiConsole.MarkupLine($"[red]Error: {exp.Message}[/]");
        }
        return "";
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

    public static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV) {
        try {
            using (Aes aes = Aes.Create()) {
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cipherText)) {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader reader = new StreamReader(cs))
                            return reader.ReadToEnd();
                    }
                }
            }
        } catch (Exception exp) {
            // Log or handle the exception
            AnsiConsole.MarkupLine($"[red]Error during decryption: {exp.Message}[/]");
            Environment.Exit(1);
            return "";
        }
    }


        public static (byte[], byte[]) GetIVandKey(string password)
        {
            using(Aes aes = Aes.Create()) {
                aes.Padding = PaddingMode.PKCS7;
                return (aes.Key, aes.IV);
            }
        }
    }
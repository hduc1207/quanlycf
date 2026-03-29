using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace QuanLyQuanCafe.Utils
{
    public static class SecurityHelper
    {
        private static readonly string SecretKey = ConfigurationManager.AppSettings["EncryptionKey"];

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;
            byte[] key = Convert.FromBase64String(SecretKey);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;
            try
            {
                byte[] fullCipher = Convert.FromBase64String(cipherText);
                byte[] key = Convert.FromBase64String(SecretKey);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    byte[] iv = new byte[16];
                    Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                    aes.IV = iv;
                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (MemoryStream ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                // Nếu dữ liệu trong DB là dữ liệu cũ chưa bị mã hoá, nó sẽ lỗi khi giải mã.
                // Ta catch lỗi và trả về nguyên chuỗi cũ để app không bị crash.
                return cipherText;
            }
        }
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return password;
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
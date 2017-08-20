using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto.Web.Core.Helpers
{
    public static class CommonHelper
    {
        private const string InitVector = "LY6H6S4R6azHBsS3";
        private const string PassPhrase = "a9GybAVLtgBRvEHh";
        private const int Keysize = 256;

        public static string GetHash(string value)
        {
            var hashAlgorithm = new SHA256CryptoServiceProvider();
            var byteValue = System.Text.Encoding.UTF8.GetBytes(value);
            var byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static string EncryptString(string plainText)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var password = new PasswordDeriveBytes(PassPhrase, null);
            var keyBytes = password.GetBytes(Keysize / 8);

            var symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };

            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            var memoryStream = new MemoryStream();

            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string DecryptString(string cipherText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            var cipherTextBytes = Convert.FromBase64String(cipherText);

            var password = new PasswordDeriveBytes(PassPhrase, null);
            var keyBytes = password.GetBytes(Keysize / 8);

            var symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}

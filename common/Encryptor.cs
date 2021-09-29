using System;
using System.Text;
using System.Security.Cryptography;

namespace common
{
    public  class Encryptor : Encryption
    {
        public string Encrypt(string text)
        {
            getKeyFromFile(KEY_FILE_NAME);
            Aes cipher = createCipher(Key);
            cipher.IV = Convert.FromBase64String(IVBase64);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }
    }
}

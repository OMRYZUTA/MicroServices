using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace common
{
   public  class Encriptor : Encryption
    {
        public string Encript(string text)
        {
            string key = getKeyFromFile(base.KEY_FILE_NAME);
            Aes cipher = createCipher(key);
            var IVBase64 = initSymmetricEncryptionKeyIV(key);
            cipher.IV = Convert.FromBase64String(IVBase64);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }


        private string getEncodedRandomString(int length)
        {
            var base64 = Convert.ToBase64String(generateRandomBytes(length));
            return base64;
        }

        private byte[] generateRandomBytes(int length)
        {
            var byteArray = new byte[length];
            RandomNumberGenerator.Fill(byteArray);
            return byteArray;
        }
    }
}

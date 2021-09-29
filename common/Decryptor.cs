using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace common
{
    public class Decryptor: Encryption
    {
        public string Decrypt(string encryptedText)
        {
            string key = getKeyFromFile(base.KEY_FILE_NAME);
            Aes cipher = createCipher(key);
            var IVBase64 = initSymmetricEncryptionKeyIV(key);
            cipher.IV = Convert.FromBase64String(IVBase64);

            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}

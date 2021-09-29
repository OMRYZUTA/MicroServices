using System;
using System.Text;
using System.Security.Cryptography;

namespace common
{
    public class Decryptor
    {
        private readonly EncryptionContext Context;
      
        public Decryptor()
        {
            Context = new EncryptionContext();
        }
        public string Decrypt(string encryptedText)
        {
            Aes cipher = Context.CreateCipher();
            cipher.IV = Convert.FromBase64String(Context.IVBase64);

            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}

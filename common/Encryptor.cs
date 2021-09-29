using System;
using System.Text;
using System.Security.Cryptography;

namespace common
{
    public  class Encryptor 
    {
        private readonly EncryptionContext Context;
        public Encryptor()
        {
            Context = new EncryptionContext();
        }

        public string Encrypt(string text)
        {
        
            Aes cipher = Context.CreateCipher();
            cipher.IV = Convert.FromBase64String(Context.IVBase64);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }
    }
}

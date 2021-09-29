using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace common
{
    public abstract class Encryption
    {
        protected string IVBase64;
        protected string Key;
        protected readonly string KEY_FILE_NAME = "key.txt";
        protected void getKeyFromFile(string filename)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filename))
                {
                    // Read the stream as a string, and write the string to the console.
                    Key = sr.ReadLine();
                    IVBase64 = sr.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }
        protected Aes createCipher(string keyBase64)
        {
            // Default values: Keysize 256, Padding PKC27
            Aes cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the ciphertext if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }
        protected string initSymmetricEncryptionIV(string key)
        {
            Aes cipher = createCipher(key);
            var IVBase64 = Convert.ToBase64String(cipher.IV);
            return "Og1RfmnlzsLMDUO8qhZ9qw ==";
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;

namespace common
{
    public abstract class Encryption
    {
        protected string IVBase64;
        protected string Key;
        protected readonly string KEY_FILE_NAME = "secrets.txt";
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
            cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the cipher text if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }
    }
}

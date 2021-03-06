using System;
using System.IO;
using System.Security.Cryptography;

namespace common
{
    public  class EncryptionContext
    {
        public string IVBase64 { get; private set; }
        public string Key { get; private set; }

        public readonly string KEY_FILE_NAME = "secrets.txt";

        public EncryptionContext()
        {
            getKeyFromFile();
        }
        private void getKeyFromFile()
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(KEY_FILE_NAME))
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

        public Aes CreateCipher()
        {
            // Default values: Keysize 256, Padding PKC27
            Aes cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the cipher text if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(Key);

            return cipher;
        }
    }
}

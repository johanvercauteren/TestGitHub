using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication5
{
    class Crypt
    {
        // Encrypt or decrypt a file, saving the results in another file.
        public static void EncryptFile(string password, string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, true);
        }

        public static void DecryptFile(string password, string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, false);
        }



        public static void EncryptString(string password, string StringIn, out string StringOut)
        {

            using (MemoryStream StreamIn = new MemoryStream(Encoding.ASCII.GetBytes(StringIn)))
            {
                using (MemoryStream StreamOut = new MemoryStream())
                {
                    CryptStream(password, StreamIn, StreamOut, true);

                    var en = StreamOut.ToArray();
                    StringOut = Convert.ToBase64String(en); 
                    //StreamOut.Flush();
                    //StreamOut.Position = 0;
                    //StreamReader _SR = new StreamReader(StreamOut);
                    //StringOut = _SR.ReadToEnd();
                }
            }

        }

        public static void DecryptString(string password, string StringIn, out string StringOut)
        {
            byte[] BytesIn = Convert.FromBase64String(StringIn);
            using (MemoryStream StreamIn = new MemoryStream(BytesIn))
            {
                using (MemoryStream StreamOut = new MemoryStream())
                {
                     CryptStream(password, StreamIn, StreamOut, false);

                     var en = StreamOut.ToArray();
                     StringOut = Encoding.ASCII.GetString(en);
                }
            }

        }



        private static void CryptFile(string password, string in_file, string out_file, bool encrypt)
        {
            // Create input and output file streams.
            using (FileStream in_stream = new FileStream(in_file, FileMode.Open, FileAccess.Read))
            {
                using (FileStream out_stream = new FileStream(out_file, FileMode.Create, FileAccess.Write))
                {
                    // Encrypt/decrypt the input stream into
                    // the output stream.
                    CryptStream(password, in_stream, out_stream, encrypt);
                }
            }
        }

        // Encrypt the data in the input stream into the output stream.
        private static void CryptStream(string password, Stream in_stream, Stream out_stream, bool encrypt)
        {
            // Make an AES service provider.
            //RSACryptoServiceProvider aes_provider = new RSACryptoServiceProvider();
            AesCryptoServiceProvider aes_provider = new AesCryptoServiceProvider();
            aes_provider.Padding = PaddingMode.ISO10126;
                
            // Find a valid key size for this provider.
            int key_size_bits = 0;
            for (int i = 1024; i > 1; i--)
            {
                if (aes_provider.ValidKeySize(i))
                {
                    key_size_bits = i;
                    break;
                }
            }
            //Debug.Assert(key_size_bits > 0);
            Console.WriteLine("Key size: " + key_size_bits);

            // Get the block size for this provider.
            int block_size_bits = aes_provider.BlockSize;

            // Generate the key and initialization vector.
            byte[] key = null;
            byte[] iv = null;
            byte[] salt = { 0x1, 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };
            MakeKeyAndIV(password, salt, key_size_bits, block_size_bits, out key, out iv);

            // Make the encryptor or decryptor.
            ICryptoTransform crypto_transform;
            if (encrypt)
            {
                crypto_transform = aes_provider.CreateEncryptor(key, iv);
            }
            else
            {
                crypto_transform = aes_provider.CreateDecryptor(key, iv);
            }

            // Attach a crypto stream to the output stream.
            // Closing crypto_stream sometimes throws an
            // exception if the decryption didn't work
            // (e.g. if we use the wrong password).
            try
            {
                using (CryptoStream crypto_stream = new CryptoStream(out_stream, crypto_transform, CryptoStreamMode.Write))
                {
                    // Encrypt or decrypt the file.
                    const int block_size = 1024;
                    byte[] buffer = new byte[block_size];
                    int bytes_read;
                    while (true)
                    {
                        // Read some bytes.
                        bytes_read = in_stream.Read(buffer, 0, block_size);
                        if (bytes_read == 0) break;

                        // Write the bytes into the CryptoStream.
                        crypto_stream.Write(buffer, 0, bytes_read);
                    }


                    //string lala = new StreamReader(out_stream).ReadToEnd();

                } // using crypto_stream 
            }
            catch
            {
            }

            crypto_transform.Dispose();
        }

        // Use the password to generate key bytes.
        private static void MakeKeyAndIV(string password, byte[] salt,int key_size_bits, int block_size_bits,out byte[] key, out byte[] iv)
        {
            Rfc2898DeriveBytes derive_bytes = new Rfc2898DeriveBytes(password, salt, 1000);

            key = derive_bytes.GetBytes(key_size_bits / 8);
            iv = derive_bytes.GetBytes(block_size_bits / 8);
        }
    }
}

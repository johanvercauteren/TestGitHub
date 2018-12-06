using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApplication5
{
    class crypt2
    {
        #region EncryptBytes
        static private byte[] EncryptBytes(byte[] KeyIn, byte[] PlainTextIn)
        {
            using (RijndaelManaged _Cipher = new RijndaelManaged())
            {
                _Cipher.Key = KeyIn;
               
                using (ICryptoTransform _Encryptor = _Cipher.CreateEncryptor())
                {
                    byte[] _CipherText = _Encryptor.TransformFinalBlock(PlainTextIn, 0, PlainTextIn.Length);

                    // IV is prepended to ciphertext
                    return _Cipher.IV.Concat(_CipherText).ToArray();
                }
            }
        }
        #endregion

        #region DecryptBytes
        static private byte[] DecryptBytes(byte[] KeyIn, byte[] PackedIn)
        {

            using (RijndaelManaged _Cipher = new RijndaelManaged())
            {
                _Cipher.Key = KeyIn;

                int _IVSize = _Cipher.BlockSize / 8;

                _Cipher.IV = PackedIn.Take(_IVSize).ToArray();

                using (ICryptoTransform _Encryptor = _Cipher.CreateDecryptor())
                {
                    return _Encryptor.TransformFinalBlock(PackedIn, _IVSize, PackedIn.Length - _IVSize);
                }
            }
        }
        #endregion

        static private byte[] AddMac(byte[] key, byte[] data)
        {
            using (var hmac = new HMACSHA256(key))
            {
                var macBytes = hmac.ComputeHash(data);

                // HMAC is appended to data
                return data.Concat(macBytes).ToArray();
            }
        }

        static private bool BadMac(byte[] found, byte[] computed)
        {
            int mismatch = 0;

            // Aim for consistent timing regardless of inputs
            for (int i = 0; i < found.Length; i++)
            {
                mismatch += found[i] == computed[i] ? 0 : 1;
            }

            return mismatch != 0;
        }

        static private byte[] RemoveMac(byte[] key, byte[] data)
        {
            using (var hmac = new HMACSHA256(key))
            {
                int macSize = hmac.HashSize / 8;

                var packed = data.Take(data.Length - macSize).ToArray();

                var foundMac = data.Skip(packed.Length).ToArray();

                var computedMac = hmac.ComputeHash(packed);

                if (BadMac(foundMac, computedMac))
                {
                    throw new Exception("Bad MAC");
                }

                return packed;
            }
        }

        static private List<byte[]> DeriveTwoKeys(string password)
        {
            var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 ,9 };

            var kdf = new Rfc2898DeriveBytes(password, salt, 10000);

            var bytes = kdf.GetBytes(32); // Two keys 128 bits each

            return new List<byte[]> { bytes.Take(16).ToArray(), bytes.Skip(16).ToArray() };
        }

        static public byte[] EncryptString(string password, String message)
        {
            var keys = DeriveTwoKeys(password);

            var plaintext = Encoding.UTF8.GetBytes(message);

            var packed = EncryptBytes(keys[0], plaintext);

            return AddMac(keys[1], packed);
        }

        static public String DecryptString(string password, byte[] secret)
        {
            var keys = DeriveTwoKeys(password);

            var packed = RemoveMac(keys[1], secret);

            var plaintext = DecryptBytes(keys[0], packed);

            return Encoding.UTF8.GetString(plaintext);
            //yZDh06ZiZ/K8lkdAub0aVoJv9ZLbB9qn5eYjhq63xBBomavF+1zmWHcwZSLp6KkypXBQcqcpsb3povF8EvWBmp7Thos+/aM1JTJUM62WFpQ=
            //X+eUqfyVClBzS2TctZVkbqDdTg1kw5LiLnqIDt+PT5lLnlXWS8MMj6PRLF+Y6esflKiK2ZJjPpWX2xBaDPbju9rXBgaC+zmw6PZufZZ5DIQ=
        }
    }
}

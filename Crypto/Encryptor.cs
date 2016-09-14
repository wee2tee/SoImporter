using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    public static class Encryptor
    {
        // One way encrypt without salt
        public static string MD5Hash(this string string_to_encrypt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(string_to_encrypt));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        // One way encrypt with salt
        public static string MD5WithSaltHash(this string string_to_encrypt, string salt)
        {
            HMACMD5 hmacMD5 = new HMACMD5(salt.GetBytes());
            byte[] encrypted_string = hmacMD5.ComputeHash(string_to_encrypt.GetBytes());

            return encrypted_string.GetString();
        }

        // Convert string to byte[]
        private static byte[] GetBytes(this string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        // Convert byte[] to string
        private static string GetString(this byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}

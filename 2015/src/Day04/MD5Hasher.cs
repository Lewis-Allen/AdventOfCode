using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public class MD5Hasher
    {
        public static long FindFirstWithLeadingZeroes(string key, int noOfZeroes)
        {
            long counter = 0;
            var hashedString = "AAAAAAAA";
            string prefix = new string('0', noOfZeroes);
            while (!hashedString.StartsWith(prefix))
            {
                counter++;
                string current = key + counter;
                hashedString = CreateMD5(current);
            }

            return counter;
        }

        // Nicked from stack overflow
        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

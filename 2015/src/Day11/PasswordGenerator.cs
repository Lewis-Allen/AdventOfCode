using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day11
{
    public static class PasswordGenerator
    {
        public static string FindNextPassword(string current)
        {
            var chars = current.ToCharArray();
            IncrementChar(chars, 0);

            while (!IsValidPassword(new string(chars)))
            {
                IncrementChar(chars, 0);
            }

            return new string(chars);
        }

        private static void IncrementChar(char[] chars, int index)
        {
            int val = chars[^(index + 1)];
            if (val == 122)
            {
                chars[^(index + 1)] = 'a';
                IncrementChar(chars, index + 1);
            }
            else
            {
                chars[^(index + 1)] = (char)(val + 1);
            }
        }

        private static bool IsValidPassword(string password)
        {
            if (password.Length != 8 ||
               Regex.IsMatch(password, @"[iol]") ||
               !IncreasingLettersCheck(password) ||
               !UniquePairsCheck(password))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private static bool UniquePairsCheck(string password)
        {
            var matches = Regex.Matches(password, @"(.)\1");

            if (matches.Count > 1)
            {
                char stored = matches[0].Value[0];

                for (int i = 1; i < matches.Count; i++)
                {
                    char check = matches[i].Value[0];

                    if (check != stored)
                        return true;
                }
            }

            return false;
        }

        private static bool IncreasingLettersCheck(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] + 1 == password[i + 1] &&
                    password[i + 1] == password[i + 2] - 1)
                    return true;
            }

            return false;
        }
    }
}

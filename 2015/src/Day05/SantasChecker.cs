using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day05
{
    public class SantasChecker
    {
        public static bool CheckString(string input) =>
            Regex.Matches(input, "[aeiou]").Count >= 3 && 
            Regex.IsMatch(input, "(.)\\1+") && 
            !Regex.IsMatch(input, "ab|cd|pq|xy");

        public static bool CheckStringRefined(string input) =>
            Regex.IsMatch(input, "(..).*\\1") && Regex.IsMatch(input, "(.).\\1");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day04
{
    public static class PasswordValidator
    {
        public static bool ValidatePasswordPartOne(string password)
        {
            return password.Length == 6
                && Regex.IsMatch(password, @"(\d)\1")
                && Regex.IsMatch(password, @"^(?=\d{6}$)0*1*2*3*4*5*6*7*8*9*$");
        }

        public static bool ValidatePasswordPartTwo(string password)
        {
            return Regex.IsMatch(password, @"^(?=\d{6}$)0*1*2*3*4*5*6*7*8*9*$")
                && Regex.IsMatch(password, @"([^0]|^)00([^0]|$)|([^1]|^)11([^1]|$)|([^2]|^)22([^2]|$)|([^3]|^)33([^3]|$)|([^4]|^)44([^4]|$)|([^5]|^)55([^5]|$)|([^6]|^)66([^6]|$)|([^7]|^)77([^7]|$)|([^8]|^)88([^8]|$)|([^9]|^)99([^9]|$)");
        }
    }
}

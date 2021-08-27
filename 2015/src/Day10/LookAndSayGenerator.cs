using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    public static class LookAndSayGenerator
    {
        public static string Generate(string input) =>
            string.Join("", Regex.Matches(input, @"([\d])\1*")
                .Select(m => m.Length.ToString() + m.Value[0]));
    }
}

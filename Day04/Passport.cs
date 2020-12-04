using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day04
{
    public record Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColour { get; set; }
        public string EyeColour { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

        public bool IsValid()
        {
            return
                int.TryParse(BirthYear, out int birthYear) && birthYear >= 1920 && birthYear <= 2002 &&
                int.TryParse(IssueYear, out int issueYear) && issueYear >= 2010 && issueYear <= 2020 &&
                int.TryParse(ExpirationYear, out int expirationYear) && expirationYear >= 2020 && expirationYear <= 2030 &&
                Regex.IsMatch(Height ?? "", "(1(([5-8][0-9])|(9[0-3]))cm)|(((59)|(6[0-9])|(7[0-6]))in)") &&
                Regex.IsMatch(HairColour ?? "", "#[\\da-f]{6}") &&
                Regex.IsMatch(EyeColour ?? "", "amb|blu|brn|gry|grn|hzl|oth") &&
                Regex.IsMatch(PassportID ?? "", "^[\\d]{9}$");
        }
    }
}

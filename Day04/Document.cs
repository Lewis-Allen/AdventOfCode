using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day04
{
    public record Document
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColour { get; set; }
        public string EyeColour { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsValid()
        {
            return
                ValidateYear(BirthYear, 4, 1920, 2002) && 
                ValidateYear(IssueYear, 4, 2010, 2020) &&
                ValidateYear(ExpirationYear, 4, 2020, 2030) &&
                ValidateHeight(Height) &&
                ValidateHair(HairColour) &&
                ValidateEyeColour(EyeColour) &&
                ValidatePassportID(PassportID);
        }

        public bool ValidateYear(string value, int length, int min, int max)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (!(length == 0 || value.Length == length)) return false;

            if (int.TryParse(value, out int year))
            {
                return year >= min && year <= max;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateHeight(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (!int.TryParse(Regex.Match(value, @"\d+").Value, out int number)) return false;

            if (value.Contains("cm"))
            {
                return number >= 150 && number <= 193;
            }
            else if (value.Contains("in"))
            {
                return number >= 59 && number <= 76;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateHair(string value) => (!string.IsNullOrEmpty(value) && Regex.Match(value, "#[\\da-f]{6}").Success);

        public bool ValidateEyeColour(string value) => !string.IsNullOrEmpty(value) &&
                                                        (value == "amb" ||
                                                        value == "blu" ||
                                                        value == "brn" ||
                                                        value == "gry" ||
                                                        value == "grn" ||
                                                        value == "hzl" ||
                                                        value == "oth");

        public bool ValidatePassportID(string value) => (!string.IsNullOrEmpty(value) && value.Length == 9 && Regex.Match(value, "[\\d]{9}").Success);
    }
}

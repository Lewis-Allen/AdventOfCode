using System.Text.RegularExpressions;

namespace Day08
{
    public static class CharacterCounter
    {
        public static int GetCharacters(string line)
        {
            return line.Length + 2 - Regex.Unescape(line).Length;
        }

        public static int GetCharactersEncode(string line)
        {
            return line.Replace("\\", "--").Replace("\"", "--").Length + 2 - line.Length;
        }
    }
}

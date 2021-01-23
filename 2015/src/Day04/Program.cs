using System;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "yzbqklnj";
            Console.WriteLine("Part One---");
            Console.WriteLine(MD5Hasher.FindFirstWithLeadingZeroes(input, 5));

            Console.WriteLine("Part Two---");
            Console.WriteLine(MD5Hasher.FindFirstWithLeadingZeroes(input, 6));
        }
    }
}

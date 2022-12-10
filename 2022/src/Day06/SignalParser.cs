namespace Day06;

public class SignalParser
{
    public static int GetStartIndicator(string input, int length)
    {
        for (var i = length; i < input.Length; i++)
        {
            var hashSet = new HashSet<char>();

            for (int j = i; j > i - length; j--)
            {
                hashSet.Add(input[j]);
            }

            if (hashSet.Count == length)
                return i+1;

        }

        return 0;
    }
}

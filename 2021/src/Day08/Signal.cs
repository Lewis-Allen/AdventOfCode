using System.Text.RegularExpressions;

namespace Day08
{
    public class Signal
    {
        private static readonly Regex SIGNAL_EXPRESSION = new(@"\w+", RegexOptions.Compiled);

        public Dictionary<int, string> NumberLookup { get; set; } = new();
        public Dictionary<char, char> CharLookup { get; set; } = new();

        public int[] Outputs { get; set; }

        public Signal(string instruction)
        {
            var instructions = SIGNAL_EXPRESSION.Matches(instruction);

            var signals = instructions.Take(10).Select(m => new string(m.Value.OrderBy(m => m).ToArray())).ToList();
            var outputs = instructions.TakeLast(4).Select(m => new string(m.Value.OrderBy(m => m).ToArray())).ToArray();

            NumberLookup[1] = signals.Where(s => s.Length == 2).First();
            signals.Remove(NumberLookup[1]);

            NumberLookup[4] = signals.Where(s => s.Length == 4).First();
            signals.Remove(NumberLookup[4]);

            NumberLookup[7] = signals.Where(s => s.Length == 3).First();
            signals.Remove(NumberLookup[7]);

            NumberLookup[8] = signals.Where(s => s.Length == 7).First();
            signals.Remove(NumberLookup[8]);
            
            NumberLookup[9] = signals.Where(s =>
            {
                if (s.Length != 6)
                    return false;

                var check = NumberLookup[8].Except(s).ToArray().First();

                return !NumberLookup[4].Contains(check);
            }).First();
            signals.Remove(NumberLookup[9]);

            NumberLookup[6] = signals.Where(s =>
            {
                if (s.Length != 6)
                    return false;

                var check = NumberLookup[8].Except(s).ToArray().First();

                return NumberLookup[7].Contains(check);
            }).First();
            signals.Remove(NumberLookup[6]);

            NumberLookup[0] = signals.Where(s => s.Length == 6).First();
            signals.Remove(NumberLookup[0]);

            CharLookup['a'] = NumberLookup[7].Except(NumberLookup[1]).First();
            CharLookup['e'] = NumberLookup[8].Except(NumberLookup[9]).First();
            CharLookup['c'] = NumberLookup[1].Except(NumberLookup[6]).First();
            CharLookup['f'] = NumberLookup[1].Except(new char[] { CharLookup['c'] }).First();
            CharLookup['d'] = NumberLookup[8].Except(NumberLookup[0]).First();
            
            NumberLookup[5] = new string(NumberLookup[6].Except(new char[] { CharLookup['e'] }).ToArray());
            signals.Remove(NumberLookup[5]);

            CharLookup['b'] = NumberLookup[4].Except(new char[] { CharLookup['c'], CharLookup['d'], CharLookup['f'] }).First();
            CharLookup['g'] = NumberLookup[8].Except(NumberLookup[4]).Except(new char[] { CharLookup['a'], CharLookup['e'] }).First();

            NumberLookup[2] = new string(new char[] { CharLookup['a'], CharLookup['c'], CharLookup['d'], CharLookup['e'], CharLookup['g'] }.OrderBy(x => x).ToArray());
            signals.Remove(NumberLookup[2]);

            NumberLookup[3] = signals.First();

            Outputs = new int[outputs.Length];
            for(int i = 0; i < outputs.Length; i++)
            {
                var output = outputs[i];
                Outputs[i] = NumberLookup.Keys.Where(k => NumberLookup[k] == output).First();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class IntcodeComputerArray
    {
        public Dictionary<int, IntcodeComputer2> Computers { get; private set; } = new();

        public int RunProgram(string program)
        {
            int result = 0;
            for (var i = 0; i <= 99999; i++)
            {
                Computers = new();
                var phaseSettings = new List<int>()
                {
                    i % 10,
                    i / 10 % 10,
                    i / 100 % 10,
                    i / 1000 % 10,
                    i / 10000 % 10
                };

                // Should do this properly really...
                if (new HashSet<int>(phaseSettings).Count < 5)
                    continue;

                var input = 0;
                bool halted = false;

                while (!halted)
                {
                    for (var ps = 0; ps < phaseSettings.Count; ps++)
                    {
                        var phaseSetting = phaseSettings[ps];
                        IntcodeComputer2 computer = GetComputer(program, phaseSetting);
                        computer.RunProgram(phaseSetting, input);
                        input = computer._output[^1];

                        if (ps == 4 && computer.Halted)
                        {
                            halted = true;
                            if (input > result)
                                result = input;

                        }
                    }
                }
            }

            return result;
        }

        private IntcodeComputer2 GetComputer(string program, int phaseSetting)
        {
            if (!Computers.ContainsKey(phaseSetting))
            {
                var computer = new IntcodeComputer2(program);
                Computers[phaseSetting] = computer;
            }

            return Computers[phaseSetting];
        }
    }
}

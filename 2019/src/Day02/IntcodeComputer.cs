using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class IntcodeComputer
    {
        private int[] _program;

        public IntcodeComputer(string program)
        {
            SetProgram(program);
        }

        public void SetProgram(string program)
        {
            _program = program.Split(",").Select(i => int.Parse(i)).ToArray();
        }

        public int RunProgramPartOne()
        {
            var position = 0;

            while(position < _program.Length)
            {
                int opcode = _program[position];
                switch(opcode)
                {
                    // Add
                    case 1:
                        int addFirstOperand = _program[position +1];
                        int addSecondOperand = _program[position + 2];
                        int addDestination = _program[position + 3];

                        _program[addDestination] = _program[addFirstOperand] + _program[addSecondOperand];
                        position += 4;
                        break;

                    // Multiply
                    case 2:
                        int multFirstOperand = _program[position + 1];
                        int multSecondOperand = _program[position + 2];
                        int multDestination = _program[position + 3];

                        _program[multDestination] = _program[multFirstOperand] * _program[multSecondOperand];
                        position += 4;
                        break;

                    // Exit
                    case 99:
                        position = _program.Length;
                        break;

                    default:
                        throw new ArgumentException($"Invalid program - Position {position}, Value {_program[position]}");
                }
            }

            return _program[0];
        }

        public int this[int index]
        {
            get => _program[index];
            set => _program[index] = value;
        }

        public string RetrieveProgramState()
        {
            return string.Join(',', _program.Select(i => i.ToString()));
        }
    }
}

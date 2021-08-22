using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class IntcodeComputer
    {
        private int[] _program;
        public List<int> _output { get; } = new();

        public IntcodeComputer(string program)
        {
            SetProgram(program);
        }

        public void SetProgram(string program)
        {
            _program = program.Split(",").Select(i => int.Parse(i)).ToArray();
        }

        public int RunProgramPartOne(int input)
        {
            var position = 0;

            while (position < _program.Length)
            {
                int opcode = _program[position];
                int operation = Math.Abs(opcode) % 100;

                switch (operation)
                {
                    // Add
                    case 1:
                        int addFirstOperand = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];
                        int addSecondOperand = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];

                        int addDestination = _program[position + 3];
                        _program[addDestination] = addFirstOperand + addSecondOperand;

                        position += 4;
                        break;

                    // Multiply
                    case 2:
                        int multFirstOperand = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];
                        int multSecondOperand = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];

                        int multDestination = _program[position + 3];
                        _program[multDestination] = multFirstOperand * multSecondOperand;

                        position += 4;
                        break;

                    // Input
                    case 3:
                        _program[_program[position + 1]] = input;
                        position += 2;
                        break;

                    // Output
                    case 4:
                        int output = _program[_program[position + 1]];
                        _output.Add(output);
                        position += 2;
                        break;

                    // Jump if true
                    case 5:
                        int jumpT = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];

                        if(jumpT != 0)
                        {
                            position = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];
                        }
                        else
                        {
                            position += 3;
                        }
                        break;

                    // Jump if false
                    case 6:
                        int jumpF = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];

                        if (jumpF == 0)
                        {
                            position = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];
                        }
                        else
                        {
                            position += 3;
                        }
                        break;

                    // Less than
                    case 7:
                        int lessThanFirstOperand = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];
                        int lessThanSecondOperand = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];

                        _program[_program[position + 3]] = lessThanFirstOperand < lessThanSecondOperand ? 1 : 0;
                        position += 4;
                        break;

                    // Equals
                    case 8:
                        int equalsFirstOperand = (opcode / 100) % 10 == 1 ? _program[position + 1] : _program[_program[position + 1]];
                        int equalsSecondOperand = (opcode / 1000) % 10 == 1 ? _program[position + 2] : _program[_program[position + 2]];

                        _program[_program[position + 3]] = equalsFirstOperand == equalsSecondOperand ? 1 : 0;
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

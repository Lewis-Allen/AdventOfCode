using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class IntcodeComputer
    {
        private int[] _program;
        public List<int> _output { get; } = new();
        public bool Halted { get; private set; } = false;
        private int Position = 0;
        public bool PhaseSettingSet { get; private set; } = false;

        public IntcodeComputer(string program)
        {
            SetProgram(program);
        }

        public void SetProgram(string program)
        {
            _program = program.Split(",").Select(i => int.Parse(i)).ToArray();
        }

        public int RunProgram(int phaseSetting, int input)
        {
            Position = 0;

            while (Position < _program.Length)
            {
                int opcode = _program[Position];
                int operation = Math.Abs(opcode) % 100;

                switch (operation)
                {
                    // Add
                    case 1:
                        int addFirstOperand = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];
                        int addSecondOperand = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];

                        int addDestination = _program[Position + 3];
                        _program[addDestination] = addFirstOperand + addSecondOperand;

                        Position += 4;
                        break;

                    // Multiply
                    case 2:
                        int multFirstOperand = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];
                        int multSecondOperand = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];

                        int multDestination = _program[Position + 3];
                        _program[multDestination] = multFirstOperand * multSecondOperand;

                        Position += 4;
                        break;

                    // Input
                    case 3:
                        _program[_program[Position + 1]] = PhaseSettingSet ? input : phaseSetting;
                        PhaseSettingSet = true;
                        Position += 2;
                        break;

                    // Output
                    case 4:
                        int output = _program[_program[Position + 1]];
                        _output.Add(output);
                        Position += 2;
                        break;

                    // Jump if true
                    case 5:
                        int jumpT = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];

                        if(jumpT != 0)
                        {
                            Position = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];
                        }
                        else
                        {
                            Position += 3;
                        }
                        break;

                    // Jump if false
                    case 6:
                        int jumpF = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];

                        if (jumpF == 0)
                        {
                            Position = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];
                        }
                        else
                        {
                            Position += 3;
                        }
                        break;

                    // Less than
                    case 7:
                        int lessThanFirstOperand = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];
                        int lessThanSecondOperand = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];

                        _program[_program[Position + 3]] = lessThanFirstOperand < lessThanSecondOperand ? 1 : 0;
                        Position += 4;
                        break;

                    // Equals
                    case 8:
                        int equalsFirstOperand = (opcode / 100) % 10 == 1 ? _program[Position + 1] : _program[_program[Position + 1]];
                        int equalsSecondOperand = (opcode / 1000) % 10 == 1 ? _program[Position + 2] : _program[_program[Position + 2]];

                        _program[_program[Position + 3]] = equalsFirstOperand == equalsSecondOperand ? 1 : 0;
                        Position += 4;
                        break;

                    // Exit
                    case 99:
                        Position = _program.Length;
                        Halted = true;
                        break;

                    default:
                        throw new ArgumentException($"Invalid program - Position {Position}, Value {_program[Position]}");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class Circuit
    {
        private readonly Dictionary<string, string> Values = new();

        public Circuit(string instructions)
        {
            var lines = instructions.Split("\r\n")
                .Select(line => line.Split("->", StringSplitOptions.TrimEntries))
                .ToArray();

            foreach(var line in lines)
            {
                Values.Add(line[1], line[0]);
            }
        }

        public ushort GetValueOf(string wire)
        {
            if (!Values.ContainsKey(wire))
                throw new ArgumentException("Wire not found", nameof(wire));

            var expression = Values[wire];
            var chunks = expression.Split(" ");

            ushort operand1;
            ushort operand2;
            ushort result;

            if (expression.Contains("NOT"))
            {
                operand1 = ParseOperand(chunks[1]);

                result = (ushort)~operand1;
            }
            else if (expression.Contains("AND"))
            {
                operand1 = ParseOperand(chunks[0]);
                operand2 = ParseOperand(chunks[2]);

                result = (ushort)(operand1 & operand2);
            }
            else if (expression.Contains("OR"))
            {
                operand1 = ParseOperand(chunks[0]);
                operand2 = ParseOperand(chunks[2]);

                result = (ushort)(operand1 | operand2);
            }
            else if (expression.Contains("LSHIFT"))
            {
                operand1 = ParseOperand(chunks[0]);
                operand2 = ParseOperand(chunks[2]);

                result = (ushort)(operand1 << operand2);
            }
            else if (expression.Contains("RSHIFT"))
            {
                operand1 = ParseOperand(chunks[0]);
                operand2 = ParseOperand(chunks[2]);

                result = (ushort)(operand1 >> operand2);
            }
            else
            {
                operand1 = ParseOperand(chunks[0]);

                result = operand1;
            }

            // Memoize result for efficiency
            Values[wire] = result.ToString();

            return result;
        }

        public void SetWire(string wire, string expression)
        {
            Values[wire] = expression;
        }

        private ushort ParseOperand(string operand)
        {
            if (!ushort.TryParse(operand, out ushort result))
                result = GetValueOf(operand);

            return result;
        }
    }
}

using System.Diagnostics;
using System.Text;

namespace Day05;

public class StackHolder
{
    public List<Stack<char>> stacks = new();

    public StackHolder(string[] stackLines)
    {
        var last = stackLines.Last();
        for(var x = 0; x < last.Length; x++) 
        {
            if (last[x] == ' ')
                continue;

            var stack = new Stack<char>();

            for(var y = stackLines.Length - 2; y >= 0; y--)
            {
                var c = stackLines[y][x];
                if (c == ' ')
                    break;

                stack.Push(c);
            }

            stacks.Add(stack);
        }
    }

    public void ApplyInstruction9000(Instruction instruction)
    {
        for(var i = 0; i < instruction.Number; i++)
        {
            var item = stacks[instruction.Source-1].Pop();

            stacks[instruction.Destination-1].Push(item);
        }    
    }

    public void ApplyInstruction9001(Instruction instruction)
    {
        var buffer = new Stack<char>();
        for (var i = 0; i < instruction.Number; i++)
        {
            var item = stacks[instruction.Source - 1].Pop();

            buffer.Push(item);
        }

        for (var i = 0; i < instruction.Number; i++)
        {
            stacks[instruction.Destination - 1].Push(buffer.Pop());
        }
    }

    public string GetMessage()
    {
        StringBuilder sb = new();

        foreach(var stack in stacks)
        {
            sb.Append(stack.Peek());
        }

        return sb.ToString();
    }
}

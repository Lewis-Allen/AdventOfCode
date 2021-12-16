using System.Text;

namespace Day16;

public class PacketDecoder
{
    public static Packet DecodeString(string input)
    {
        var binary = ConvertToBinary(input);

        int pointer = 0;
        var packet = ParsePacket(binary, ref pointer);

        return packet;
    }

    private static Packet ParsePacket(string binary, ref int i)
    {
        var packet = new Packet();

        packet.Version = Convert.ToInt32(binary[i..(i + 3)], 2);
        i += 3;

        packet.TypeID = Convert.ToInt32(binary[i..(i + 3)], 2);
        i += 3;

        if (packet.TypeID == 4)
        {
            bool isLast = false;
            StringBuilder sb = new();

            do
            {
                isLast = binary[i] == '0';
                i += 1;

                sb.Append(binary[i..(i + 4)]);
                i += 4;
            }
            while (!isLast);

            packet.Value = Convert.ToInt64(sb.ToString(), 2);
        }
        else
        {
            var lengthTypeId = Convert.ToInt32(binary[i].ToString(), 2);
            i++;

            if (lengthTypeId == 0)
            {
                var bitCount = Convert.ToInt32(binary[i..(i + 15)], 2);
                i += 15;

                var targetPointer = i + bitCount;
                while(i < targetPointer)
                {
                    packet.SubPackets.Add(ParsePacket(binary, ref i));
                }
            }
            else
            {
                var packetCount = Convert.ToInt32(binary[i..(i + 11)], 2);
                i += 11;

                for(int pi = 0; pi < packetCount; pi++)
                {
                    packet.SubPackets.Add(ParsePacket(binary, ref i));
                }
            }

        }

        return packet;
    }

    private static string ConvertToBinary(string input)
    {
        var builder = new StringBuilder();

        foreach (char c in input)
        {
            builder.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
        }

        return builder.ToString();
    }
}

namespace Day16;

public record Packet
{
    public int Version { get; set; }
    public int TypeID { get; set; }
    public List<Packet> SubPackets { get; set; } = new();
    public long Value { private get; set; }

    public long GetVersionSum() => 
        Version + SubPackets.Sum(sp => sp.GetVersionSum());

    public long GetValue() => TypeID switch
    {
        0 => SubPackets.Sum(s => s.GetValue()),
        1 => SubPackets.Aggregate(1L, (a, b) => a * b.GetValue()),
        2 => SubPackets.Select(s => s.GetValue()).Min(),
        3 => SubPackets.Select(s => s.GetValue()).Max(),
        4 => Value,
        5 => SubPackets[0].GetValue() > SubPackets[1].GetValue() ? 1 : 0,
        6 => SubPackets[0].GetValue() < SubPackets[1].GetValue() ? 1 : 0,
        7 => SubPackets[0].GetValue() == SubPackets[1].GetValue() ? 1 : 0,
        _ => throw new Exception("Invalid Type ID"),
    };
}

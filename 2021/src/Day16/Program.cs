using Day16;

var hex = File.ReadAllText("Inputs/16.txt");

var packet = PacketDecoder.DecodeString(hex);

Console.WriteLine($"The version sum for the supplied packet is {packet.GetVersionSum()}.");

var totalvalue = packet.GetValue();

Console.WriteLine($"The value of the packet is {totalvalue}.");
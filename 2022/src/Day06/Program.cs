using Day06;

var signal = File.ReadAllText("Inputs/6.txt");

var packetStart = SignalParser.GetStartIndicator(signal, 4);

Console.WriteLine($"The packet start indicator is at position {packetStart}.");

var messageStart = SignalParser.GetStartIndicator(signal, 14);

Console.WriteLine($"The message start indicator is at position {messageStart}.");
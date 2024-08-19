using Day01;

var lines = File.ReadAllLines("input.txt");

var result = Calibrator.GetCalibrationValueTotal(lines);

Console.WriteLine($"The sum of all calibration values is {result}.");

result = Calibrator.GetRealCalibrationValueTotal(lines);

Console.WriteLine($"The sum of all REAL calibration values is {result}.");
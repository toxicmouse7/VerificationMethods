using Task3;

var data = BatteryCalculationData.CreateFromStrings(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

Console.WriteLine(BatteryCalculator.Calculate(data));
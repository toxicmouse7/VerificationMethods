using Task2;

var data = OperatorCalculationData.CreateFromStrings(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

Console.WriteLine(OperatorCalculator.Calculate(data));
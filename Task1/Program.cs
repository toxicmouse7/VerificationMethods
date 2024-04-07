using Task1;

var salary = Console.ReadLine();
var intensityWorkSum = Console.ReadLine();

var indicators = new List<string>();

for (var indicatorString = Console.ReadLine(); indicatorString is not null; indicatorString = Console.ReadLine())
{
    indicators.Add(indicatorString);
}

SalaryCalculator.Calculate(SalaryData.CreateFromStrings(salary, intensityWorkSum, indicators));
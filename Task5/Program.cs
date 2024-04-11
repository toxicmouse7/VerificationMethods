using Task5;

var marksInfo = new List<string>();

for (var markInfoString = Console.ReadLine(); markInfoString is not null; markInfoString = Console.ReadLine())
{
    marksInfo.Add(markInfoString);
}

var data = ScholarshipCalculationData.CreateFromStrings(marksInfo, Console.ReadLine());

Console.WriteLine(ScholarshipCalculator.Calculate(data));
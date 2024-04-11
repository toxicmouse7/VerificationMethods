using Task4;

var data = PhonePaymentCalculationData.CreateFromStrings(
    Console.ReadLine(),
    Console.ReadLine(),
    Console.ReadLine(),
    Console.ReadLine(),
    Console.ReadLine(),
    Console.ReadLine());

Console.WriteLine();

Console.WriteLine(PhonePaymentCalculation.CalculateFirstTarif(data));
Console.WriteLine(PhonePaymentCalculation.CalculateSecondTarif(data));
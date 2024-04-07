namespace Task2.Tests;

public class OperatorCalculatorUnitTests
{
    [Theory]
    [InlineData(5, 10, 5, 5)]       // Минимальное количество операторов
    [InlineData(10, 10, 5, 10)]     // Минимальное количество операторов
    [InlineData(15, 20, 5, 30)]     // Удвоенное количество операторов
    [InlineData(20, 11, 5, 40)]     // Удвоенное количество операторов
    [InlineData(25, 29, 5, 50)]     // Удвоенное количество операторов
    [InlineData(30, 31, 5, 90)]     // Тройное количество операторов
    [InlineData(30, 50, 5, 90)]     // Тройное количество операторов
    [InlineData(40, 60, 5, 120)]    // Тройное количество операторов
    [InlineData(3, 10, 10, 4)]      // Минимальное количество операторов * 20%
    [InlineData(10, 10, 20, 12)]    // Минимальное количество операторов * 20%
    [InlineData(2, 29, 50, 5)]      // Удвоенное количество операторов * 20%
    [InlineData(15, 20, 30, 36)]    // Удвоенное количество операторов * 20%
    [InlineData(20, 11, 40, 48)]    // Удвоенное количество операторов * 20%
    [InlineData(31, 31, 60, 112)]    // Тройное количество операторов * 20%
    [InlineData(32, 50, 70, 116)]    // Тройное количество операторов * 20%
    [InlineData(40, 60, 80, 144)]   // Тройное количество операторов * 20%
    public void Calculate_ReturnsCorrectOperatorsCount(int minOperatorsCount, int callsPerHour,
        double meanCallDurationInMinutes, int expected)
    {
        // Arrange
        var calculationData = new OperatorCalculationData(minOperatorsCount, callsPerHour, meanCallDurationInMinutes);

        // Act
        var result = OperatorCalculator.Calculate(calculationData);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("5", "10", "5", 5)]       // Минимальное количество операторов
    [InlineData("10", "10", "5", 10)]     // Минимальное количество операторов
    [InlineData("15", "20", "5", 30)]     // Удвоенное количество операторов
    [InlineData("20", "11", "5", 40)]     // Удвоенное количество операторов
    [InlineData("25", "29", "5", 50)]     // Удвоенное количество операторов
    [InlineData("30", "31", "5", 90)]     // Тройное количество операторов
    [InlineData("30", "50", "5", 90)]     // Тройное количество операторов
    [InlineData("40", "60", "5", 120)]    // Тройное количество операторов
    [InlineData("3", "10", "10", 4)]      // Минимальное количество операторов * 20%
    [InlineData("10", "10", "20", 12)]    // Минимальное количество операторов * 20%
    [InlineData("2", "29", "50", 5)]      // Удвоенное количество операторов * 20%
    [InlineData("15", "20", "30", 36)]    // Удвоенное количество операторов * 20%
    [InlineData("20", "11", "40", 48)]    // Удвоенное количество операторов * 20%
    [InlineData("31", "31", "60", 112)]    // Тройное количество операторов * 20%
    [InlineData("32", "50", "70", 116)]    // Тройное количество операторов * 20%
    [InlineData("40", "60", "80", 144)]   // Тройное количество операторов * 20%
    public void Calculate_FromStrings_ReturnsCorrectOperatorsCount(string minOperatorsCountStr, string callPerHourStr,
        string meanCallDurationInMinutesStr, int expected)
    {
        // Arrange
        var calculationData =
            OperatorCalculationData.CreateFromStrings(minOperatorsCountStr, callPerHourStr,
                meanCallDurationInMinutesStr);

        // Act
        var result = OperatorCalculator.Calculate(calculationData);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "10", "5")] // Нулевое значение MinOperatorsCount
    [InlineData("10", "0", "5")] // Нулевое значение CallsPerHour
    [InlineData(null, "10", "5")] // Нулевое значение MinOperatorsCount
    [InlineData("10", null, "5")] // Нулевое значение CallsPerHour
    [InlineData("10", "10", null)] // Нулевое значение MeanCallDurationInMinutes
    [InlineData("abc", "10", "5")] // Некорректное значение MinOperatorsCount
    [InlineData("10", "abc", "5")] // Некорректное значение CallsPerHour
    [InlineData("10", "10", "abc")] // Некорректное значение MeanCallDurationInMinutes
    [InlineData("-5", "10", "5")] // Отрицательное значение MinOperatorsCount
    [InlineData("10", "-10", "5")] // Отрицательное значение CallsPerHour
    [InlineData("10", "10", "-5")] // Отрицательное значение MeanCallDurationInMinutes
    public void CreateFromStrings_ThrowsArgumentException_ForInvalidInputs(string minOperatorsCountStr,
        string callPerHourStr, string meanCallDurationInMinutesStr)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            OperatorCalculationData.CreateFromStrings(minOperatorsCountStr, callPerHourStr,
                meanCallDurationInMinutesStr));
    }
}
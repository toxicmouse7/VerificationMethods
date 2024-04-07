using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Task1.Tests;

public class SalaryCalculatorUnitTests
{
    [Theory]
    [InlineData(
        1000,
        500,
        new object[] { new[] { "56", "True" }, new[] { "95", "True" } },
        1875)] // Все показатели достигнуты
    [InlineData(
        1000,
        500,
        new object[] { new[] { "100", "True" }, new[] { "41", "False" } },
        1500)] // Не все показатели достигнуты
    public void Calculate_ReturnsCorrectSalary(decimal salary, decimal intensityWorkSum, object[] indicatorData,
        decimal expected)
    {
        // Arrange
        var indicators = indicatorData
            .Select(data =>
            {
                var castedData = (string[])data;
                return new Indicator(decimal.Parse(castedData[0]), bool.Parse(castedData[1]));
            })
            .ToList();
        var salaryData = new SalaryData(salary, intensityWorkSum, indicators);

        // Act
        var result = SalaryCalculator.Calculate(salaryData);

        // Assert
        Assert.Equal(expected, result);
    }
}
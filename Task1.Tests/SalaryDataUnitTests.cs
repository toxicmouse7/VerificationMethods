using FluentAssertions;

namespace Task1.Tests;

public class SalaryDataUnitTests
{
    [Theory]
    [InlineData("1000", "500", new[] { "54 True", "97 True" }, 1000, 500)] // Нормальный случай
    public void CreateFromStrings_ValidInput_ReturnsCorrectSalaryData(
        string? salaryStr,
        string? intensityWorkSumStr,
        string[] indicatorStrs,
        decimal expectedSalary,
        decimal expectedIntensityWorkSum)
    {
        // Arrange
        var expectedIndicators = indicatorStrs
            .Select(i =>
            {
                var split = i.Split();
                return new Indicator(decimal.Parse(split[0]), bool.Parse(split[1]));
            })
            .ToList();

        // Act
        var result = SalaryData.CreateFromStrings(salaryStr, intensityWorkSumStr, indicatorStrs);

        // Assert
        
        Assert.Equal(expectedSalary, result.Salary);
        Assert.Equal(expectedIntensityWorkSum, result.IntensityWorkSum);
        result.Indicators.Should().BeEquivalentTo(expectedIndicators);
    }

    [Theory]
    [InlineData("abc", "500", new[] { "200 True", "300 True" })] // Некорректное значение для Salary
    [InlineData("1000", "abc", new[] { "200 True", "300 True" })] // Некорректное значение для IntensityWorkSum
    [InlineData("1000", "500", new[] { "200", "300 True" })] // Некорректный формат для индикатора
    [InlineData("1000", "500", new[] { "200 True", "300" })] // Некорректный формат для индикатора
    [InlineData("1000", "500", new[] { "200 True", "abc True" })] // Некорректное значение для индикатора
    [InlineData("1000", "500", new[] { "200 abc", "300 True" })] // Некорректное значение для индикатора
    [InlineData(null, null, new[] { "200 True", "300 True" })] // Null значения для Salary и IntensityWorkSum
    [InlineData("1000", null, new[] { "200 True", "300 True" })] // Null значение для IntensityWorkSum
    [InlineData(null, "500", new[] { "200 True", "300 True" })] // Null значение для Salary
    public void CreateFromStrings_ThrowsArgumentException_ForInvalidInputs(string? salaryStr,
        string? intensityWorkSumStr, string[] indicatorStrs)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            SalaryData.CreateFromStrings(salaryStr, intensityWorkSumStr, indicatorStrs));
    }
}
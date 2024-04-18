namespace Task5.Tests;

public class ScholarshipCalculatorTests
{
    [Theory]
    [InlineData(new[] { "4,True", "4,True", "4,True", "4,True" }, "100", 100)] // All marks are 4 and in time
    [InlineData(new[] { "5,True", "5,True", "5,True", "5,True" }, "100", 125)] // All marks are 5 and in time
    [InlineData(new[] { "6,True", "6,True", "6,True", "6,True" }, "100", 150)] // All marks are 6 and in time
    public void Calculate_ReturnsCorrectValue(string[] marksInfoStr, string AStr, decimal expected)
    {
        // Arrange
        var data = ScholarshipCalculationData.CreateFromStrings(marksInfoStr, AStr);

        // Act
        var result = ScholarshipCalculator.Calculate(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "3,True", "4,True", "5,True", "6,True" }, "100", 0)] // One mark is less than or equal to 3
    [InlineData(new[] { "4,False", "5,True", "6,True", "7,True" }, "100", 0)] // One mark is in time and less than or equal to 3
    [InlineData(new[] { "4,True", "4,True", "4,True", "5,False" }, "100", 0)] // One mark is in time and less than or equal to 3
    public void Calculate_ReturnsZero(string[] marksInfoStr, string AStr, decimal expected)
    {
        // Arrange
        var data = ScholarshipCalculationData.CreateFromStrings(marksInfoStr, AStr);

        // Act
        var result = ScholarshipCalculator.Calculate(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "4,True", "4,True", "4,True", "4,True" }, "100", 1)] // All marks are 4 and in time
    [InlineData(new[] { "5,True", "5,True", "5,True", "5,True" }, "100", 125)] // All marks are 5 and in time
    [InlineData(new[] { "4,True", "5,True", "4,True", "5,True" }, "100", 125)] // Mix of 4 and 5 marks, all in time
    public void Calculate_ReturnsCorrectValueWithDifferentMarks(string[] marksInfoStr, string AStr, decimal expected)
    {
        // Arrange
        var data = ScholarshipCalculationData.CreateFromStrings(marksInfoStr, AStr);

        // Act
        var result = ScholarshipCalculator.Calculate(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { "4,True", "4,True", "4,True", "4,True" }, "-100")] // Negative A value
    [InlineData(new[] { "4,True", "4,True", "4,True", "4,True" }, "abc")] // Invalid A value
    [InlineData(null, "100")] // Null marksInfo
    [InlineData(new[] { "4,True", "4,True", "4,True", "4,True" }, null)] // Null A
    public void CreateFromStrings_ThrowsArgumentException(string[] marksInfoStr, string AStr)
    {
        // Assert
        Assert.ThrowsAny<ArgumentException>(() => ScholarshipCalculationData.CreateFromStrings(marksInfoStr, AStr));
    }
}
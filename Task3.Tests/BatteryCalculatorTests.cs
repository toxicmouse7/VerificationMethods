namespace Task3.Tests;

public class BatteryCalculatorTests
{
    [Theory]
    [InlineData(1, 1, 1, 1)] // MinBatteryCount <= 1, MeanBlackoutTime <= 1
    [InlineData(1, 2, 1, 2)] // MinBatteryCount <= 1, MeanBlackoutTime > 1 and < 12
    [InlineData(1, 12, 1, 2)] // MinBatteryCount <= 1, MeanBlackoutTime >= 12
    [InlineData(2, 1, 1, 2)] // MinBatteryCount > 1, MeanBlackoutTime <= 1
    [InlineData(2, 2, 1, 3)] // MinBatteryCount > 1, MeanBlackoutTime > 1 and < 12
    [InlineData(2, 12, 1, 4)] // MinBatteryCount > 1, MeanBlackoutTime >= 12
    [InlineData(1, 1, 2, 2)] // BlackoutMonthlyFrequency > 1
    public void Calculate_ReturnsCorrectValue(int minBatteryCount, double meanBlackoutTime,
        int blackoutMonthlyFrequency, int expected)
    {
        // Arrange
        var data = new BatteryCalculationData(minBatteryCount, meanBlackoutTime, blackoutMonthlyFrequency);

        // Act
        var result = BatteryCalculator.Calculate(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, "2", "1")] // null MinBatteryCount
    [InlineData("1", null, "1")] // null MeanBlackoutTime
    [InlineData("1", "2", null)] // null BlackoutMonthlyFrequency
    [InlineData("-1", "2", "1")] // negative MinBatteryCount
    [InlineData("1", "-2", "1")] // negative MeanBlackoutTime
    [InlineData("1", "2", "-1")] // negative BlackoutMonthlyFrequency
    [InlineData("abc", "2", "1")] // invalid MinBatteryCount format
    [InlineData("1", "abc", "1")] // invalid MeanBlackoutTime format
    [InlineData("1", "2", "abc")] // invalid BlackoutMonthlyFrequency format
    [InlineData("0", "2", "1")] // zero MinBatteryCount
    public void CreateFromStrings_ThrowsArgumentException(string minBatteryCount, string meanBlackoutTime,
        string blackoutMonthlyFrequency)
    {
        // Assert
        Assert.ThrowsAny<ArgumentException>(() =>
            BatteryCalculationData.CreateFromStrings(minBatteryCount, meanBlackoutTime, blackoutMonthlyFrequency));
    }
}
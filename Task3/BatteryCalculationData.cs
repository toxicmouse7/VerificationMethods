namespace Task3;

public record BatteryCalculationData(int MinBatteryCount, double MeanBlackoutTime, int BlackoutMonthlyFrequency)
{
    public static BatteryCalculationData CreateFromStrings(
        string? minBatteryCountStr,
        string? meanBlackoutTimeStr,
        string? blackoutMonthlyFrequencyStr)
    {
        if (minBatteryCountStr is null || meanBlackoutTimeStr is null || blackoutMonthlyFrequencyStr is null)
        {
            throw new ArgumentNullException();
        }

        if (!int.TryParse(minBatteryCountStr, out var minBatteryCount) || minBatteryCount <= 0)
        {
            throw new ArgumentException();
        }

        if (!double.TryParse(meanBlackoutTimeStr, out var meanBlackoutTime) || meanBlackoutTime < 0)
        {
            throw new ArgumentException();
        }

        if (!int.TryParse(blackoutMonthlyFrequencyStr, out var blackoutMonthlyFrequency) ||
            blackoutMonthlyFrequency < 0)
        {
            throw new ArgumentException();
        }

        return new BatteryCalculationData(minBatteryCount, meanBlackoutTime, blackoutMonthlyFrequency);
    }
}
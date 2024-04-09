namespace Task3;

public static class BatteryCalculator
{
    public static int Calculate(BatteryCalculationData data)
    {
        var modificator = data.BlackoutMonthlyFrequency > 1 ? 1.5 : 1;

        return data.MeanBlackoutTime switch
        {
            <= 1 => Convert.ToInt32(Math.Ceiling(data.MinBatteryCount * modificator)),
            > 1 and < 12 => Convert.ToInt32(Math.Ceiling(data.MinBatteryCount * 1.2 * modificator)),
            _ => Convert.ToInt32(Math.Ceiling(data.MinBatteryCount * 2 * modificator))
        };
    }
}
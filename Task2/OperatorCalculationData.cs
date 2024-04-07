namespace Task2;

public record OperatorCalculationData(int MinOperatorsCount, int CallsPerHour, double MeanCallDurationInMinutes)
{
    public static OperatorCalculationData CreateFromStrings(
        string? minOperatorsCountStr,
        string? callPerHourStr,
        string? meanCallDurationInMinutesStr)
    {
        if (minOperatorsCountStr is null || callPerHourStr is null || meanCallDurationInMinutesStr is null)
            throw new ArgumentException("Some arguments are null");

        if (!int.TryParse(minOperatorsCountStr, out var minOperatorsCount) || minOperatorsCount <= 0)
            throw new ArgumentException("MinOperatorsCount is invalid", nameof(minOperatorsCountStr));

        if (!int.TryParse(callPerHourStr, out var callsPerHour) || callsPerHour <= 0)
            throw new ArgumentException("CallsPerHour is invalid", nameof(minOperatorsCountStr));

        if (!double.TryParse(meanCallDurationInMinutesStr, out var meanCallDurationInMinutes)
            || meanCallDurationInMinutes < 0)
            throw new ArgumentException("MeanCallDurationInMinutes is invalid", nameof(minOperatorsCountStr));

        return new OperatorCalculationData(minOperatorsCount, callsPerHour, meanCallDurationInMinutes);
    }
}
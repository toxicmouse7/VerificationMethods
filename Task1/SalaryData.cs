namespace Task1;

public record SalaryData(decimal Salary, decimal IntensityWorkSum, IReadOnlyCollection<Indicator> Indicators)
{
    public static SalaryData CreateFromStrings(
        string? salaryStr,
        string? intensityWorkSumStr,
        IEnumerable<string>? indicatorStrs)
    {
        if (salaryStr is null || intensityWorkSumStr is null || indicatorStrs is null)
            throw new ArgumentException("Some arguments are null");
        
        if (!decimal.TryParse(salaryStr, out var salary))
            throw new ArgumentException("Salary is not valid", nameof(salaryStr));
        if (!decimal.TryParse(intensityWorkSumStr, out var intensityWorkSum))
            throw new ArgumentException("IntensityWorkSum is not valid", nameof(intensityWorkSumStr));

        var indicators = indicatorStrs
            .Select(i =>
            {
                var split = i.Split();
                if (split.Length != 2)
                    throw new ArgumentException($"Invalid indicator: {i}", nameof(indicatorStrs));

                if (!decimal.TryParse(split.First(), out var value))
                    throw new ArgumentException("Invalid indicator value", nameof(indicatorStrs));
                if (!bool.TryParse(split.Last(), out var achieved))
                    throw new ArgumentException("Invalid indicator achievement", nameof(indicatorStrs));

                return new Indicator(value, achieved);
            })
            .ToList();

        return new SalaryData(salary, intensityWorkSum, indicators);
    }
}
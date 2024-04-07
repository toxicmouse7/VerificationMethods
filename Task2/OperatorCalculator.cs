namespace Task2;

public static class OperatorCalculator
{
    public static int Calculate(OperatorCalculationData calculationData)
    {
        var operatorsCount = calculationData.CallsPerHour switch
        {
            <= 10 => calculationData.MinOperatorsCount,
            > 10 and < 30 => calculationData.MinOperatorsCount * 2,
            _ => calculationData.MinOperatorsCount * 3
        };

        if (calculationData.MeanCallDurationInMinutes > 5)
            operatorsCount = Convert.ToInt32(Math.Ceiling(operatorsCount * 1.2));

        return operatorsCount;
    }
}
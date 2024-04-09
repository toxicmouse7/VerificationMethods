namespace Task5;

public static class ScholarshipCalculator
{
    public static decimal Calculate(ScholarshipCalculationData data)
    {
        if (data.MarksInfo.Any(markInfo => !markInfo.IsInTime || markInfo.Mark <= 3))
            return 0;

        if (data.MarksInfo.All(markInfo => markInfo.Mark == 4))
            return data.A;
        
        if (data.MarksInfo.All(markInfo => markInfo.Mark is 4 or 5))
            return data.A * 1.25m;

        return data.A * 1.5m;
    }
}
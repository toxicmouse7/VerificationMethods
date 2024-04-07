namespace Task1;

public static class SalaryCalculator
{
    public static decimal Calculate(SalaryData salaryData)
    {
        if (salaryData.Indicators.All(i => i.Achieved))
            return (salaryData.Salary + salaryData.IntensityWorkSum) * 1.25m;

        return salaryData.Salary + salaryData.IntensityWorkSum;
    }
}
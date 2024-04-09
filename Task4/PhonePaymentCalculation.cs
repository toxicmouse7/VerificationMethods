namespace Task4;

public static class PhonePaymentCalculation
{
    public static decimal CalculateFirstTarif(PhonePaymentCalculationData data)
    {
        if (data.T <= data.K)
            return data.A;

        return data.A + (data.T - data.K) * data.B;
    }
    
    public static decimal CalculateSecondTarif(PhonePaymentCalculationData data)
    {
        if (data.T <= data.K)
            return data.C * data.T;

        return data.D * data.T;
    }
}
namespace Task1;

public record Indicator
{
    public decimal Value { get; }
    public bool Achieved { get; }
    
    public Indicator(decimal value, bool achieved)
    {
        if (value is < 0 or > 100)
            throw new ArgumentException("Value is < 0 or > 100", nameof(value));

        Value = value;
        Achieved = achieved;
    }
}
namespace Task4;

public record PhonePaymentCalculationData(int K, int T, decimal A, decimal B, decimal C, decimal D)
{
    public static PhonePaymentCalculationData CreateFromStrings(
        string? Kstr,
        string? Tstr,
        string? Astr,
        string? Bstr,
        string? Cstr,
        string? Dstr)
    {
        if (Kstr is null || Tstr is null || Astr is null || Bstr is null || Cstr is null || Dstr is null)
        {
            throw new ArgumentNullException();
        }

        if (!int.TryParse(Kstr, out var k) || k < 0)
        {
            throw new ArgumentException("Invalid value for K");
        }

        if (!int.TryParse(Tstr, out var t) || t < 0)
        {
            throw new ArgumentException("Invalid value for T");
        }

        if (!decimal.TryParse(Astr, out var a) || a < 0)
        {
            throw new ArgumentException("Invalid value for A");
        }

        if (!decimal.TryParse(Bstr, out var b) || b < 0)
        {
            throw new ArgumentException("Invalid value for B");
        }

        if (!decimal.TryParse(Cstr, out var c) || c < 0)
        {
            throw new ArgumentException("Invalid value for C");
        }

        if (!decimal.TryParse(Dstr, out var d) || d < 0)
        {
            throw new ArgumentException("Invalid value for D");
        }

        return new PhonePaymentCalculationData(k, t, a, b, c, d);
    }
}
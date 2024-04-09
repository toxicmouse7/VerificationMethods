namespace Task4.Tests;

public class PhonePaymentCalculationTests
{
    [Theory]
    [InlineData(5, 3, 10, 2, 1, 1, 10)] // T <= K, first tariff
    [InlineData(5, 7, 10, 2, 1, 1, 14)] // T > K, first tariff
    public void CalculateFirstTarif_ReturnsCorrectValue(int K, int T, decimal A, decimal B, decimal C, decimal D, decimal expected)
    {
        // Arrange
        var data = new PhonePaymentCalculationData(K, T, A, B, C, D);

        // Act
        var result = PhonePaymentCalculation.CalculateFirstTarif(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 3, 1, 1, 10, 1, 30)] // T <= K, second tariff
    [InlineData(5, 7, 1, 1, 10, 1, 7)] // T > K, second tariff
    public void CalculateSecondTarif_ReturnsCorrectValue(int K, int T, decimal A, decimal B, decimal C, decimal D, decimal expected)
    {
        // Arrange
        var data = new PhonePaymentCalculationData(K, T, A, B, C, D);

        // Act
        var result = PhonePaymentCalculation.CalculateSecondTarif(data);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-1", "3", "10", "2", "1", "1")] // invalid K
    [InlineData("5", "-3", "10", "2", "1", "1")] // invalid T
    [InlineData("5", "3", "-10", "2", "1", "1")] // invalid A
    [InlineData("5", "3", "10", "-2", "1", "1")] // invalid B
    [InlineData("5", "3", "10", "2", "-1", "1")] // invalid C
    [InlineData("5", "3", "10", "2", "1", "-1")] // invalid D
    public void CreateFromStrings_ThrowsArgumentException(string Kstr, string Tstr, string Astr, string Bstr, string Cstr, string Dstr)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => PhonePaymentCalculationData.CreateFromStrings(Kstr, Tstr, Astr, Bstr, Cstr, Dstr));
    }
}
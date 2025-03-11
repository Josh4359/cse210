public class Fraction
{
    int _numerator;

    int _denominator;

    public Fraction()
    {
        _numerator = 1;

        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;

        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;

        _denominator = denominator;
    }

    public float GetNumerator() => _numerator;

    public float GetDenominator() => _denominator;

    public string GetFractionString() => $"{_numerator}/{_denominator}";

    public double GetDecimalValue() => (double)_numerator / _denominator;
}
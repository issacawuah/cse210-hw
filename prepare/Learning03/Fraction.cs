public class Fraction
{
    private int numerator;
    private int denominator;

    // No-argument constructor
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }

    // Constructor with two parameters
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int denominator)
    {
        this.denominator = denominator;
    }

    // To get fraction string
    public string GetFractionString()
    {
        return numerator + "/" + denominator;
    }

    // get decimal value
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}

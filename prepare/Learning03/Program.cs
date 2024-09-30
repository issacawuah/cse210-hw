using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating fractions using different constructors
        Fraction fraction1 = new Fraction(); 
        Fraction fraction2 = new Fraction(6); 
        Fraction fraction3 = new Fraction(6, 7); 

        // Displaying fractions and their decimal values
        Console.WriteLine(fraction1.GetFractionString()); 
        Console.WriteLine(fraction1.GetDecimalValue()); 

        Console.WriteLine(fraction2.GetFractionString()); 
        Console.WriteLine(fraction2.GetDecimalValue()); 

        Console.WriteLine(fraction3.GetFractionString()); 
        Console.WriteLine(fraction3.GetDecimalValue()); 

        // Additional fraction example
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString()); 
        Console.WriteLine(fraction4.GetDecimalValue()); 
    }
}

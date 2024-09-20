 using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int SquareNumber(int number)  // Changed 'squaredNumber' to 'SquareNumber'
    {
        return number * number;
    }

    static int PromptUserNumber()  // Added this missing method
    {
        Console.WriteLine("Please enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    static void DisplayResult(string name, int square)  // Changed the parameter name to 'square'
    {
        Console.WriteLine($"{name}, the square of your number is {square}");  // Corrected 'sqaure' to 'square'
    }
}

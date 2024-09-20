 using System;

class Program
{
    static void Main(string[] args)
    {
        // Random number can use
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Loop until the guess is correct
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your magic number? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it right!");
            }
        }
    }
}

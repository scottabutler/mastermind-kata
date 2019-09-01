using System;

namespace Mastermind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Enter a combination to be guessed using using numbers for each colour.");
            Console.WriteLine("Ie Red Pink Green Blue would be 1256. Duplicates are allowed.");

            var counter = 1;
            foreach (var colour in Enum.GetValues(typeof(Colours)))
            {
                Console.WriteLine($"{counter}: {colour}");
                counter++;
            }

            Console.Write("Secret: ");
            var secret = Console.ReadLine();
        }
    }
}

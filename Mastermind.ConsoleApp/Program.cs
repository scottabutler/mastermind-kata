using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Generating secret...");

            var secret = new List<Colours>();
            Random r = new Random();
            for (var i = 0; i < 4; i++)
            {
                int random = r.Next(0, 5);
                secret.Add((Colours)random);
            }

            Console.WriteLine("Enter guess or q to quit");
            // Console.WriteLine(Print(secret));

            var input = string.Empty;
            do
            {
                Console.Write("Guess: ");
                input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    Console.WriteLine("Secret was: " + Print(secret));
                    continue;
                }

                if (input.Length != 4)
                {
                    Console.WriteLine("Invalid input, please enter 4 characters");
                    continue;
                }

                var guess = new List<Colours>();
                var allowedInputs = new List<string> { "b", "g", "r", "o", "y", "p" };
                foreach (char c in input)
                {
                    if (!allowedInputs.Contains(c.ToString().ToLower()))
                    {
                        Console.WriteLine("Invalid input, only the following are characters are allowed: b, g, r, o, y, p");
                        break;
                    }

                    guess.Add(MapToColour(c.ToString()));
                }

                var result = Core.Eval(secret: secret, guess: guess);
                Console.WriteLine(result.AsString());
                Console.WriteLine();

                if (result.WellPlaced == 4)
                {
                    Console.WriteLine("You win! The secret was " + Print(secret));
                    break;
                }
            } while (input.ToLower() != "q");
        }

        private static Colours MapToColour(string input)
        {
            switch (input.ToLower())
            {
                case "r":
                    return Colours.Red;
                case "p":
                    return Colours.Pink;
                case "b":
                    return Colours.Blue;
                case "g":
                    return Colours.Green;
                case "o":
                    return Colours.Orange;
                case "y":
                    return Colours.Yellow;
                default:
                    throw new Exception("Unsupported colour: " + input);
            }
        }

        private static string Print(List<Colours> input)
        {
            return string.Join(", ", input.Select(x => x.ToString()));
        }
    }
}

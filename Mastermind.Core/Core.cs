﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Core
{
    public static class App
    {
        public static List<Colours> GenerateSecret()
        {
            var secret = new List<Colours>();
            Random r = new Random();
            for (var i = 0; i < 4; i++)
            {
                int random = r.Next(0, 5);
                secret.Add((Colours)random);
            }
            return secret;
        }

        public static GuessResult Eval(List<Colours> secret, List<Colours> guess)
        {
            if (secret == guess)
            {
                return new GuessResult(wellPlaced: secret.Count, misplaced: 0);
            }

            var wellPlacedCount = 0;
            var misplacedCount = 0;

            var newGuess = new List<Colours>();
            var newSecret = new List<Colours>();

            // Identify well placed indexes, removing them from the guess and secret if they match
            for (var i = 0; i < guess.Count(); i++)
            {
                if (guess[i] == secret[i])
                {
                    wellPlacedCount++;
                }
                else
                {
                    newGuess.Add(guess[i]);
                    newSecret.Add(secret[i]);
                }
            }

            // Identify misplaced indexes
            foreach (var s in newSecret)
            {
                if (newGuess.Contains(s))
                {
                    misplacedCount++;
                    newGuess.RemoveAt(newGuess.IndexOf(s));
                }
            }


            // Identify misplaced indexes
            // foreach (var g in newGuess.Distinct())
            // {
            //     if (newSecret.Contains(g))
            //     {
            //         // if once in secret and twice in guess, only add one
            //         // if twice in secret and once in guess, only add one
            //         // if twice in secret and twice in guess, add two
            //         var occurrencesInSecret = newSecret.Count(x => x == g);
            //         misplacedCount += occurrencesInSecret;
            //     }
            // }
            // for (var i = 0; i < newGuess.Count(); i++)
            // {

            // }

            return new GuessResult(wellPlaced: wellPlacedCount, misplaced: misplacedCount);
        }

        public static GuessResult Evaluate(Colours[] secret, Colours[] guess)
        {
            if (secret == guess)
            {
                return new GuessResult(wellPlaced: secret.Length, misplaced: 0);
            }

            var misplacedPerColour = BuildColourDictionary((x) => 0);
            var wellPlacedPerColour = BuildColourDictionary((x) => 0);
            var secretCountPerColour = BuildColourDictionary((x) => secret.Count(s => s == x));

            //Work out how many of each colour is well placed
            for (var a = 0; a < guess.Length; a++)
            {
                if (secret[a] == guess[a])
                {
                    wellPlacedPerColour[secret[a]]++;
                }
            }

            // var newSecret = new List<Colours>();
            // var newGuess = new List<Colours>();
            // for (var b = 0; b < guess.Length; b ++)
            // {
            //     if (secret[b] != guess[b])
            //     {
            //         newSecret.Add(secret[b]);
            //         newGuess.Add(guess[b]);
            //     }
            // }

            //For a given colour, the number of well placed + misplaced cannot execeed the number of times that colour occurs in the secret

            //Work out how many of each colour is misplaced
            for (var i = 0; i < guess.Length; i++)
            {
                var guessedColour = guess[i];
                if (secret[i] != guessedColour)
                {
                    //Increment the misplaced count of the guessed colour if it is in the secret
                    //and does not already exceed the number of times that colour occurs in the secret
                    if (Array.Exists(secret, x => x == guessedColour)
                        && misplacedPerColour[guessedColour] < secretCountPerColour[guessedColour]
                    )
                    {
                        misplacedPerColour[guessedColour]++;
                    }
                }
            }

            //For each colour in secret, ensure that the WP + MP <= occurrences in secret

            foreach (var colour in secret)
            {
                if (wellPlacedPerColour[colour] + misplacedPerColour[colour] > secretCountPerColour[colour])
                {
                    misplacedPerColour[colour] -= wellPlacedPerColour[colour];
                }
            }

            return new GuessResult(
                wellPlaced: wellPlacedPerColour.Select(x => x.Value).Sum(),
                misplaced: misplacedPerColour.Select(x => x.Value).Sum()
            );
        }

        private static Colours Parse(string input)
        {
            return (Colours)Enum.Parse(typeof(Colours), input);
        }

        private static Dictionary<Colours, int> BuildColourDictionary(Func<Colours, int> func)
        {
            var colourNames = Enum.GetNames(typeof(Colours));

            return colourNames
                .Select(x => Parse(x))
                .ToDictionary<Colours, Colours, int>(a => a, (a) => func(a));
        }
    }

    public enum Colours
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Pink
    }

    public struct GuessResult
    {
        public readonly int WellPlaced;
        public readonly int Misplaced;

        public GuessResult(int wellPlaced, int misplaced)
        {
            WellPlaced = wellPlaced;
            Misplaced = misplaced;
        }

        public string AsString()
        {
            return $"Well placed: {WellPlaced}, Misplaced: {Misplaced}";
        }
    }
}

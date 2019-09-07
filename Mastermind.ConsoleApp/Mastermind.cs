using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public static class Core
    {
        public static GuessResult Evaluate(Colours[] secret, Colours[] guess)
        {
            if (secret == guess)
            {
                return new GuessResult(wellPlaced: secret.Length, misplaced: 0);
            }

            var wellPlaced = 0;
            var misplacedPerColour = BuildColourDictionary((x) => 0);
            var secretCountPerColour = BuildColourDictionary((x) => secret.Count(s => s == x));

            for (var i = 0; i < guess.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    wellPlaced++;
                }
                else
                {
                    if (Array.Exists(secret, x => x == guess[i])
                        && secret[i] != guess[i]
                        && misplacedPerColour[guess[i]] < secretCountPerColour[guess[i]]
                        )
                    {
                        misplacedPerColour[guess[i]]++;
                    }
                }
            }

            return new GuessResult(
                wellPlaced: wellPlaced, 
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
        Pink,
        Orange,
        Yellow,
        Green,
        Blue
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
    }
}
using System;

namespace Mastermind
{
    public static class Core
    {
        public static GuessResult Evaluate(Colours[] secret, Colours[] guess)
        {                
            var wellPlaced = 0;
            var misplaced = 0;
            for (var i = 0; i < guess.Length; i++)
            {
                if (Array.Exists(secret, x => x == guess[i])
                    && secret[i] != guess[i])
                    {
                        misplaced++;
                    }
                
                if (secret[i] == guess[i])
                {
                    wellPlaced++;
                }
            }
            return new GuessResult(wellPlaced: wellPlaced, misplaced: misplaced);
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